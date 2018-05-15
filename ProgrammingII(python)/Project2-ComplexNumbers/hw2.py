#Rush Weigelt rw643 sec.063
from complex import complexNumbers
import sys
#required z function
def z(n,c):
    z = complexNumbers(0,0)
    for a in range (0, 10):
        ans = (z*z)+ complexNumbers(n,c)
        z = ans
    return abs(z)
#required accept function to figure out whether we mark with an x or dash. Used this method as my draw image.
def accept_c(c):
    if abs(c) <=2:
        #output includes a space to help output be as clear as possible for grader
        print('X ', end='')
    else:
        print('_ ', end='')
#required ask function to format questions properly. Asks for inputs infinitely until user types 'exit'.
def ask_number(question):
    boo = True
    while boo == True:
        try:
            user_input = input("Enter "+ question+ "(or 'exit' to exit)\n")
            if user_input == 'exit':
                print('Thank you for using our Mandelbrot Set Program.')
                sys.exit(0)
            user_input = float(user_input)
            return user_input
        #value error check to ensure user enters a number (int or float).
        except ValueError:
            print("Value Error, sorry try again")
#Start of program output/input
print('Welcome to the Mandelbrot Set!')
print('Enter "exit" at any time to quit the program')
#boolean for loop
boo = True
while boo == True:
    #Questions and assignments, variable names should be self-evident
    start_x = ask_number('Start X Point')
    end_x = ask_number('Stop X Point')
    start_y = ask_number('Start Y Point')
    end_y = ask_number('Stop Y Point')
    step = ask_number('Step Size')
    #ensure that all inputs are valid; however, error we give isn't particularly insightful
    if step<=0 or start_y>end_y or start_x>end_x:
       print('Bad Inputs! Could not render.')
    #start of loop for all valid inputs for x, y, and step. it stands for iteration.
    else:
        original_value = start_x
        it = end_y
        #loop plus necessary iteration
        while it >= start_y:
            v = start_x
            while v<=end_x:
                try:
                    d = z(v, it)
                    out = accept_c(d)
                except OverflowError:
                    print("_ ",end='')
                v += step
            start_x = original_value
            #print to break up lines properly re: desired output
            print("")
            it-= step