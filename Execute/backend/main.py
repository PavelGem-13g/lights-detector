import cv2

import cameraTest
import neural
from flask import Flask, jsonify

app = Flask(__name__)
model = neural.load_model('model.pt')
camera = []


@app.route("/")
def hello_world():
    info = detect()
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
    return neural.predict(model, img_name)


if __name__ == "__main__":
    cameraTest.list_ports()
    print("Enter port number")
    camera = cv2.VideoCapture(int(input()))
    app.run()
