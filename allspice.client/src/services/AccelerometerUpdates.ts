import { startAccelerometerUpdates, AccelerometerData } from "nativescript-accelerometer";

startAccelerometerUpdates((data: AccelerometerData) => {
    console.log("x: " + data.x + "y: " + data.y + "z: " + data.z);
}, { sensorDelay: "ui" });