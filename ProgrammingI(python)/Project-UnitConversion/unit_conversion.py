#Rush Weigelt rw643 sec064

#Dictionary with meter as base unit
meter_base = {
"centimeters" : .01,
"decimeters" : .1,
"meters" : 1,
"decameters" : 10,
"hectometers" : 100,
"kilometers" : 1000,
"inches": .0254,
"feet": .3048,
"yards": .9144,
"miles": 1609.34,
"leagues": 4828.032
}

#Opening print statements
print('Welcome to the conversion wizard.')
print('I can convert between any of the following:\n'
      ' inches\n feet\n yards\n miles\n leagues\n'
      ' centimeters\n decimeters\n meters\n'
      ' decameters\n hectometers\n kilometers')
print('Note: You must type units exactly as shown')

#User inputs
user_float = float(input('Enter value:\n'))
user_from_unit = input('Enter units you wish to convert from:\n')
user_to_unit = input('Enter units to which you want to convert:\n')

#Math based on user inputs
from_to_base = user_float * meter_base[user_from_unit]
final = from_to_base / meter_base[user_to_unit]

#Final print statement
print(' ')
print(user_float, user_from_unit, 'is', final, user_to_unit)