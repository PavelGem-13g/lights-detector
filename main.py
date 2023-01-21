import sys

import cv2
from PyQt5.QtWidgets import QApplication

import cameraTest
import neural
from myMainWindow import MyMainWindow

print(cameraTest.list_ports())
if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MyMainWindow()
    sys.exit(app.exec_())

'''model = neural.load_model('model.pt')
start_time = time.time()
neural.predict(model)

print("--- %s seconds ---" % (time.time() - start_time))'''


'''model = neural.load_model('model.pt')
camera = cv2.VideoCapture(2)
while True:
    ret, frame = camera.read()
    if not ret:
        print("failed to grab frame")
        break
    cv2.imshow("test", frame)
    cv2.waitKey(1)
    img_name = "opencv_frame_{}.png".format(0)
    cv2.imwrite(img_name, frame)
    neural.predict(model, img_name)'''