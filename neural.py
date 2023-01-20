from operator import itemgetter

import cv2
from ultralytics import YOLO
from PIL import Image


def load_model(filename: str):
    return YOLO(filename)

def predict(model):
    im1 = Image.open("PR_1.jpg")
    results = model.predict(source=im1)  # save plotted images
    lights = []
    for result in results:
        for box in result.boxes:
            lights.append([int(box[0].cls[0]), int(box[0].xyxy.tolist()[0][0])])
        #print(result.boxes[0].cls, '\n')
    lights = sorted(lights, key=itemgetter(1))
    for i in range(len(lights)):
        lights[i] = lights[i][0]
    print(lights)
    return lights