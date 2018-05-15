#Rush Weigelt rw643 sec. 064

#Imports
import sys
import math
import csv

#opening statements, prompt
print('Hello and welcome to the linear regression generator!')
print('File Options:\nages.csv\nhurricanes.csv\ntemp.csv\n'
      'voters.csv\nweights.csv\nbad_input.csv\n')
user_csv_input = str(input('Please pick a file from above:'))

#empty dictionary
x_info = []
y_info = []

#Open a file w/ possible File Not Found error notice
try:
    csv_file = open(user_csv_input)
    reader = csv.reader(csv_file)
except FileNotFoundError as e:
    print('File not found')
    sys.exit(0)

#pull all info from user csv
for row in reader:
    x_info.append(row[0])
    y_info.append(row[1])

#pull unit from user csv
    x_unit = x_info[0]
    y_unit = y_info[0]

#create a list for x and y values, removes unit from this list
    x_values = x_info
    y_values = y_info
del x_values[0]
del y_values[0]

#check inputs to be valid, convert x to int and y to float
try:
    x_values = list(map(int, x_values))
except ValueError as e:
    print('A value in the file could not be read')
    sys.exit(0)
try:
    y_values = list(map(float, y_values))
except ValueError as e:
    print('A value in the file could not be read')
    sys.exit(0)

#Math variables
xi = len(x_values)
yi = len(y_values)
xa = sum(x_values)/len(x_values)
ya = sum(y_values)/len(y_values)

#empty list to store sums for numerator and denominator of slope
m_num_values = []
m_denom_values = []

#loop for slope numerator and denomenator
counter = 0
while counter < xi:
    m_num_values.append((x_values[counter]-xa)*(y_values[counter]-ya))
    m_denom_values.append((x_values[counter]-xa) ** 2)
    counter += 1

#create m_numerator and m_denomator
m_num = sum(m_num_values)
m_denom = sum(m_denom_values)

#slope
m = m_num/m_denom

#b calculations
b = (ya - (m*xa))

#approx(x) calculations loop
counter = 0
approx_x_values = []
while counter < xi:
    approx_x_values.append((m * x_values[counter]) + b)
    counter += 1

#yi-approx(x) squared loop
counter = 0
y_minus_approx_x = []
while counter < yi:
    y_minus_approx_x.append((y_values[counter] - approx_x_values[counter])**2)
    counter += 1

#mse summation and final value, S value
mse_summation = sum(y_minus_approx_x)
mse_final = ((1/(xi-2))*mse_summation)
s = math.sqrt(mse_final)

#average error: get and store values, absolute value, average
avg_error_values = []
counter = 0
while counter < xi:
    avg_error_values.append(y_values[counter]-approx_x_values[counter])
    counter += 1
avg_error_values = list(map(abs, avg_error_values))
avg_error = sum(avg_error_values)/len(avg_error_values)

#print statements for output, ask user for input
if b < 0:
    print('The Linear Regression Line is y =', round(m, 5), '* x -', round(math.fabs(b), 5))
else:
    print('The Linear Regression Line is y =', round(m, 5), '* x +', round(b, 5))
print('Average Error for Known Values was +/-', round(avg_error, 5))
print('Regression Standard Error for Known Values was', round(s, 5))
print(' ')
print('System is ready to make predictions:')
print('to quit, type "exit" as the', x_unit)

#Estimate function
def estimate(user_value):
    estimate = (m*user_value) + b
    return estimate

#User-estimate loop, exit
if __name__ == "__main__":
    user_value = input('Enter %s:\n' % x_unit)
    while user_value != 'exit':
        try:
            user_value = int(user_value)
            estimate_value = estimate(user_value)
            print('Prediction: when', x_unit, '=', user_value, y_unit, 'is', round(estimate_value, 5))
#print("Prediction: when {} = {}, {} is {}".format(x_unit, user_value, y_unit, estimate_value))
        except ValueError as e:
            print('Invalid Input, please try again.')
        user_value = input('Enter %s:' % x_unit)
    else:
        print('Bye!')
        sys.exit(0)
csv_file.close()

