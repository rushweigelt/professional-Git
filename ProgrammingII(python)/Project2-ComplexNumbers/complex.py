#Rush Weigelt rw643 sec.063
class complexNumbers():
    def __init__(self, x, y):
        self.n = x
        self.c = y
    #create a string in form x + yi, as requested in hw2 doc
    def __str__(self):
       return '('+self.n+' + '+self.c+'i)'
    #return our real number
    def getReal(self):
        return self.n
    #return our imaginary number
    def setImaginary(self):
        return self.c
    #add overload as described in hw2 doc
    def __add__(self, other):
        return complexNumbers(self.n+other.n, self.c + other.c)
    #sub overload as described in hw2 doc
    def __sub__(self, other):
        return complexNumbers(self.n - other.n, self.c - other.c)
    #multiply overload as described in hw2 doc
    def __mul__(self, other):
        return complexNumbers(((self.n*other.n)-(self.c*other.c)), ((self.n*other.c)+(self.c*other.n)))
    #abs overload--instead of math sqrt function, used a .5 exponent for the radical
    def __abs__(self):
        return (((self.n)**2 + (self.c)**2)**(0.5))