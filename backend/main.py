import sys

import cv2

import cameraTest
import neural

from flask import Flask
from flask import jsonify

import asyncio

# if __name__ == "__main__":
#     app = QApplication(sys.argv)
#     window = MyMainWindow()
#     sys.exit(app.exec_())

'''model = neural.load_model('model.pt')
start_time = time.time()
neural.predict(model)

print("--- %s seconds ---" % (time.ti
me() - start_time))'''

# app = Flask(__name__)
# model = neural.load_model('model.pt')
# cameraTest.list_ports()
# camera = cv2.VideoCapture(2)
app = Flask(__name__)
model = neural.load_model('model.pt')
#cameraTest.list_ports()
camera = cv2.VideoCapture(1)
info = []


@app.route("/")
def hello_world():
    detect()
    return jsonify(
        config="DE10LITE",
        info=info)


def detect():
    print('detect')
    global info
    ret, frame = camera.read()
    if not ret:
        print("failed to grab frame")
    cv2.imshow("test", frame)
    cv2.waitKey(1)
    img_name = "opencv_frame_{}.png".format(0)
    cv2.imwrite(img_name, frame)
    info = neural.predict(model, img_name)


if __name__ == "__main__":
    #detect()
    app.run()
