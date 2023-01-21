# -*- coding: utf-8 -*-

import sys
import time

from PyQt5.QtCore import QTimer
from PyQt5.QtWidgets import QMainWindow, QAction, qApp, QLabel, QPushButton
from PyQt5.QtGui import QIcon, QPixmap
from ultralytics import YOLO
import cv2


import neural


class MyMainWindow(QMainWindow):

    def __init__(self):
        super().__init__()

        self.initUI()

        self.model = neural.load_model('model.pt')
        self.camera = cv2.VideoCapture(1)

        self.setGeometry(0, 0, 500, 500)
        self.setWindowTitle('Lights detector')
        self.show()
        self.update_colors([0]*10)


    def initUI(self):
        self.pixmap = QPixmap("base.jpg")
        self.pixmap = self.pixmap.scaledToHeight(200)
        self.lbl = QLabel(self)
        self.lbl.setPixmap(self.pixmap)
        self.lbl.resize(self.lbl.pixmap().width(), self.lbl.pixmap().height())
        self.lbl.move(50,50)

        self.lightLables = []
        for i in range(10):
            self.lightLable = QLabel(self)
            self.lightLable.resize(20, 20)
            self.lightLable.move(0,0)
            self.lightLable.move(40 * i, 40)
            self.lightLable.setStyleSheet("background-color: red")

            self.lightLables.append(self.lightLable)
        '''self.lightLables = QLabel(self)
        self.lightLable.resize(100,100)
        self.lightLable.setStyleSheet("background-color: white")'''



        exitAction = QAction(QIcon('exit.png'), '&Exit', self)
        exitAction.setShortcut('Ctrl+Q')
        exitAction.setStatusTip('Exit application')
        exitAction.triggered.connect(qApp.quit)

        self.statusBar()

        menubar = self.menuBar()
        fileMenu = menubar.addMenu('&File')
        fileMenu.addAction(exitAction)

        button = QPushButton('PyQt5 button', self)
        button.setToolTip('This is an example button')
        button.move(100, 70)
        button.clicked.connect(self.on_click)

    def on_click(self):
        print('Click')
        ret, frame = self.camera.read()
        if not ret:
            print("failed to grab frame")
        cv2.imshow("test", frame)
        cv2.waitKey(1)
        img_name = "opencv_frame_{}.png".format(0)
        cv2.imwrite(img_name, frame)
        self.update_colors(neural.predict(self.model, img_name))

    def change_color(self, label:QLabel, color):
        if color==0:
            label.setStyleSheet("background-color: white")
        if color==1:
            label.setStyleSheet("background-color: red")

    def update_colors(self, lights: list):
        for i in range(len(lights)):
            self.change_color(self.lightLables[i], lights[i])
        self.update()
        #cv2.waitkey(50)
        #QTimer.singleShot(4, self.update_colors(neural.predict(self.model)))
        #self.update_colors(neural.predict(self.model))
