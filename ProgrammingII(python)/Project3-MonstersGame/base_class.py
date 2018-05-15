# Rush Weigelt rw643 sec.063
#imports
import abc
#class
class Enemy(metaclass=abc.ABCMeta):
    def __init__(self, n, h, a):
        self.name = n
        self.health = h
        self.attack = a

    def __str__(self):
        self.health = str(self.health)
        self.attack = str(self.attack)
        return self.name + ' appeared to attack you! ' + self.name + ' has an attack of ' + self.attack + ' and ' + self.health + ' health points.'

    # mutators
    def setHealth(self, h):
        self.health = h
        return self.health

    def setAttack(self, a):
        self.attack = a
        return self.attack

    def setName(self, n):
        self.name = n
        return self.name

    # gettors
    def getHealth(self):
        return self.health

    def getAttack(self):
        return self.attack

    def getName(self):
        return self.name

    def doDamage(self, damage):
        if (self.shield):
            self.health = self.health - (damage // 2)
        else:
            self.health = self.health - damage

    def potion(self):
        self.health = 100

    #@abc.abstractclassmethod
    #def takeDamage(self, other):
     #   pass
    #def attackEnemy(self, other):
     #   pass


