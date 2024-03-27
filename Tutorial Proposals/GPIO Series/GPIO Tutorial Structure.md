---
title: GPIO Tutorial Structure
---

## Introduction

This series of tutorials are intended to introduce the reader to the GPIO functions in SplashKit. It
is designed for beginners and provides practical projects that introduce and reinforce relevant
concepts. The series begins by covering digital signals in particular, while demonstrating all
current GPIO functions. We intend to produce a further series of tutorials that introduce analog
signals. The series culminates in a project to integrate a joystick into SplashKit applications.

## Tutorial Series Structure

### Basic GPIO Operations

- The basic GPIO operations are explained through implementation of fundamental projects. This
  projects are intended to create an engaging experience to reinforce the learning of the reader.
- The importance of proper initialisation and cleanup of the GPIO pins is stressed throughout all
  tutorials.
- Writing to pins are first covered in 1.1 Blink an LED, while reading from pins are first covered
  in 1.2 Reading a button press.

### Sensor Interfacing Guide

- As of now, no tutorial directly covers sensor interfacing. It can be a very complex project to
  interface with a sensor
  ([See DHT examples](https://abyz.me.uk/rpi/pigpio/examples.html#pigpiod_if2%20code)), and as a
  beginner this is usually done through 3rd-party libraries.
- The possibilities in regard to sensor interfacing is still being explored and speaking to the
  mentor team regarding this is planned.

### LED Blinking Tutorial

- The entirety of the digital IO tutorials covers LED blinking. It begins by just blinking it, then
  we integrates an external button to trigger the LED blink.
- Then we move into the Pulse-Width Modulation (PWM) functions and use these to modify the LED's
  function, before finally bringing it all together and using a button to control the PWM for the
  LED.

### Joystick Integration Tutorial

- The analog series of tutorials culminates in joystick integration. The series begins by first
  briefly covering analog v digital signals before delving into analog to digital conversion.
- Then the next tutorial cover potentiometers and the conversion of their analog signal to a digital
  signal. We then use this to modify an LED like how we used PWM previously.
- It is important that we cover potentiometers as a joystick is made from potentiometers for x-axis
  and y-axis.
- The tutorial series concludes with the integration of the joystick and several buttons to create a
  rudimentary controller. The project then show how we can use this device to interact with
  SplashKit projects - such as to control a game.

## Conclusion

The series of tutorials on GPIO functions in SplashKit offers a practical guide for beginners eager
to explore electronics using a Raspberry Pi. The tutorials are designed to build a solid foundation
in hardware interfacing with software and prepare the reader for further projects involving
hardware. The series culminates with a project integrating a joystick into SplashKit applications.
The intention is to showcase the practical application of the skills learned. It offers the reader a
chance to create a basic controller for games or other projects. This series intends to leverage the
power of learning through doing. Encouraging readers to explore, experiment, and ultimately, enhance
their understanding of GPIO functionalities in the SplashKit framework. This series paves the way
for more advanced projects and applications.
