#Rush Weigelt rw643 sec. 063

class Node():
    # v = value, n = next, p = previous
    def __init__(self, v, n, p):
        self.v = v
        self. n = None
        self.p = None
    #str in format desired by rubric
    def __str__(self):
        self.v = str(self.v)
        return '[' + self.v + ']'
    #gettors
    def getNext(self):
        return self.n
    def getPrev(self):
        return self.p
    def getValue(self):
        return self.v
    #settors
    def setNext(self, n):
        self.n = n
        return self.n
    def setPrev(self, p):
        self.p = p
        return self.p
    def setValue(self, v):
        self.v = v
        return self.v