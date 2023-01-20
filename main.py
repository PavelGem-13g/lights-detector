import sys
import time
import timeit

from PyQt5.QtWidgets import QApplication

import neural
from myMainWindow import MyMainWindow

'''if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MyMainWindow()
    model = neural.load_model('model.pt')
    sys.exit(app.exec_())'''

model = neural.load_model('model.pt')
start_time = time.time()
for i in range(10):
    neural.predict(model)

print("--- %s seconds ---" % (time.time() - start_time))