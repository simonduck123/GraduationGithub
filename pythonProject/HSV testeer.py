import cv2
import cvzone
from cvzone.ColorModule import ColorFinder

cap = cv2.VideoCapture(0)

myColorFinder = ColorFinder(True)  # Set to True to see HSV image
hsvVals = {'hmin': 0, 'smin': 100, 'vmin': 50, 'hmax': 10, 'smax': 255, 'vmax': 255}

while True:
    success, img = cap.read()
    imgColor, mask = myColorFinder.update(img, hsvVals)
    cv2.imshow("Image", img)
    cv2.imshow("HSV", imgColor)
    cv2.imshow("Mask", mask)
    cv2.waitKey(1)
