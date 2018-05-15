#Rush Weigelt rw643 sec.063
#imports
from base_class import Enemy
#class
class hero(Enemy):
    #initialize with
    def __init__(self, n):
        super().__init__(n, 100, 10)
        self.name = n
        self.shield = False
        self.fireballs = 10
        self.potions = 6
    def __str__(self):
        self.health = str(self.health)
        return self.name + ' has ' + self.health + ' health points left.\n'
    def getName(self):
        return self.name
    #unique for hero, lists his remaining items (potions and fireballs).
    def getItems(self):
        self.fireballs = str(self.fireballs)
        self.potions = str(self.potions)
        return 'Remaining Supplies: '+self.fireballs+'/10 Fireballs and '+ self.potions+'/6 Potions.\n'
    #basic description
    def getDescription(self):
        return "I am " + self.name + ' and I am a mighty hero!'
    #sword attack, low damage
    def basicAttack(self, other):
        self.shield = False
        other.doDamage(10)
    def basicName(self):
        return "Sword Slash"
    #fireball attack, high damage
    def secondaryAttack(self, other):
        self.fireballs = int(self.fireballs)
        if self.fireballs > 0:
            other.doDamage(20)
            self.fireballs -= 1
        #if out of fireballs and one is used, player loses his turn
        else:
            print('You cannot use another fireball, you already used all 10!\n')
    def secondaryName(self):
        return "Fireball"
    #shield for a turn
    def defenseAttack(self, other):
        self.shield = True
    def defenseName(self):
        return "Shield"
    #unneeded technically
    def getHealth(self):
        return self.health
    #damage for the hero
    def doDamage(self, damage):
        if(self.shield) == True:
            self.health = self.health - (damage//2)
        else:
            self.health = self.health - damage
    #potion for the hero
    def potion(self):
        self.potions = int(self.potions)
        if self.potions > 0:
            self.health = 100
            self.potions -= 1
            print("Hero used a potion to return to full health.\n")
        else:
            print("Oh no, you've already used all of your potions. You might be boned here...\n")