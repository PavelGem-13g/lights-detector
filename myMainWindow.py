# -*- coding: utf-8 -*-

import sys

from PyQt5.QtWidgets import QMainWindow, QAction, qApp, QLabel
from PyQt5.QtGui import QIcon, QPixmap


class MyMainWindow(QMainWindow):

    def __init__(self):
        super().__init__()

        self.initUI()

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

    def change_color(self, label:QLabel, color):
        if color==0:
            label.setStyleSheet("background-color: white")
        if color==1:
            label.setStyleSheet("background-color: red")

    def update_colors(self, lights: list):
        for i in range(len(lights)):
            self.change_color(self.lightLables[i], lights[i])
        #self.update_colors(neural.predict(main.model))