from flask import Flask, request, redirect, jsonify, send_file
import json
import random
import string
from PIL import Image
from PIL import ImageFont
from PIL import ImageDraw
import re
import requests
from io import BytesIO
import io
import mysql.connector
from os import environ
import datetime

app = Flask(__name__)
font = ImageFont.truetype('Roboto-Light.ttf', 60)

@app.route('/')
def home():
    """Redirects to Github repository."""
    return redirect("https://github.com/macedonga/actions", code=302)

@app.route('/set', methods=['POST'])
def set():
    """ Sets user status."""
    db = mysql.connector.connect(
      host=environ.get("HOST"),
      user=environ.get("USER"),
      password=environ.get("PASSWORD"),
      database=environ.get("DATABASE")
    )
    cursor = db.cursor()
    error = str("")
    post = request.get_json(force=True)

    cursor.execute("SELECT * FROM user")

    result = cursor.fetchall()

    for x in result:
        if(post["uid"] in x):
            if(x[1] == post["token"]):
                if ".png" in post["image"]:
                    cursor.execute("UPDATE user SET status='" + post["status"] + "', image='" + post["image"] + "' WHERE uid='" + post["uid"] + "';")
                else:
                    cursor.execute("UPDATE user SET status='" + post["status"] + "', image='none' WHERE uid='" + post["uid"] + "';")
                db.commit()
                return jsonify(Success = "true", Action = "Set custom status")
            else:
                return jsonify(Success = "false", Error = "Wrong token")
    return jsonify(Success = "false", Error = "UID not found in database")

@app.route('/get', methods=['GET'])
def get():
    """Renders the status."""
    db = mysql.connector.connect(
      host=environ.get("HOST"),
      user=environ.get("USER"),
      password=environ.get("PASSWORD"),
      database=environ.get("DATABASE")
    )
    cursor = db.cursor()
    uid = request.args.get('uid')
    mode = request.args.get('mode')
    cursor.execute("SELECT * FROM user")

    result = cursor.fetchall()

    for x in result:
      if(uid in x):
          status = x[2]
          dark = False

          if mode == None:
              img = Image.open("white.png")
          if mode == "b.white":
              img = Image.open("b.white.png")
          if mode == "white":
              img = Image.open("white.png")
          if mode == "b.dark":
              img = Image.open("b.dark.png")
              dark = True
          if mode == "dark":
              img = Image.open("dark.png")
              dark = True

          draw = ImageDraw.Draw(img)
          if status != "idle":
              if dark:
                  draw.text((50, 60), status, (255, 255, 255), font=font)
              else:
                  draw.text((50, 60), status, (0, 0, 0), font=font)

              if x[3] != "none":
                  imageLink = x[3]
                  if("https://cdn.macedon.ga/actions" in imageLink):
                    if dark:
                        imageLink = imageLink.replace(".png", ".light.png")

                  print(imageLink)
                  response = requests.get(imageLink)
                  icon = Image.open(BytesIO(response.content))
                  icon = icon.resize((150, 150))
                  img.paste(icon, (625, 25), icon.convert('RGBA'))
              else:
                  icon = Image.open("unknown.png")
                  icon = icon.resize((150, 150))
                  img.paste(icon, (625, 25), icon.convert('RGBA'))
          else:
              if dark:
                  draw.text((50, 60), "No current activity", (255, 255, 255), font=font)
              else:
                  draw.text((50, 60), "No current activity", (0, 0, 0), font=font)

          final_image = io.BytesIO()
          img.save(final_image, 'PNG')
          final_image.seek(0)
          return send_file(final_image, mimetype='image/PNG')
    return jsonify(Success = "false", Error = "UID not found in database")

@app.route('/register', methods=['GET'])
def register():
    """Creates user."""
    db = mysql.connector.connect(
      host=environ.get("HOST"),
      user=environ.get("USER"),
      password=environ.get("PASSWORD"),
      database=environ.get("DATABASE")
    )
    cursor = db.cursor()
    uid = generateToken(32)
    token = generateToken(64)


    sql = "INSERT INTO user (uid, token, status, image) VALUES (%s, %s, %s, %s)"
    val = (uid, token, "idle", "none")
    cursor.execute(sql, val)

    db.commit()
    return jsonify(Success = "true", Token = token, UID = uid)

def generateToken(length):
    """Generates a token."""
    letters = string.ascii_lowercase
    result_str = ''.join(random.choice(letters) for i in range(length))
    return result_str

@app.after_request
def add_header(response):
    """Removes caching for dynamically generated content"""
    response.headers['Cache-Control'] = 'no-cache'
    response.headers["Expires"] = datetime.datetime.utcnow().strftime("%a, %d %b %Y %H:%M:%S GMT")
    return response
