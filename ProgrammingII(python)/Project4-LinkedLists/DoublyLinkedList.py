#Rush Weigelt rw643 Sec.063
class DLL():
    #init with an empty list, accepts a node
    def __init__(self, n):
        self.l = []
        self.n = n
    #complicated STR function to match rubric
    def __str__(self):
        #if length of LL is 1, just print first number
        if len(self.l) == 1:
            return self.l[0]
        #if LL is empty, print statement
        if len(self.l) == 0:
            return '[Empty List]'
        #else, print linked list as desired
        else:
            #find length of list, and create a variable to iterate
            x = len(self.l)
            x_start = 0
            # code in string form that we will EVAL later. Multiply by # of instances needed
            list_first = "self.l[a] + ' --> ' +"* x
            #loop: creates as many self.l[a] we need, then loops through and replaces 'a's with iterated #
            while x_start < x:
                x_start = str(x_start)
                list_first = list_first.replace('a', x_start, 1)
                x_start = int(x_start)
                x_start += 1
            #strips eval of the extra + --> + characters that are a byproduct
            list_first = list_first[0:-12]
            #return an evaluatable string that reads nums of ints, prints how we want, has arrows
            return eval(list_first)
    #return last node
    def last(self):
        return self.l[-1]
    #append node in list
    def append(self, n):
        self.l.append(n)
    #prepend a node to front of list
    def prepend(self, n):
        self.l.insert(0, n)
    #clear our node list
    def clear(self):
        del self.l[:]
        return self.l
    #insert after functon
    def insertAfter(self, i, n):
        x = self.l.index(i)
        x += 1
        self.l.insert(x, n)
    #find/search node list
    def find(self, i):
        i = self.l.index(i)
        return self.l[i]
    #delete node
    def delete(self, i):
        self.l.remove(i)