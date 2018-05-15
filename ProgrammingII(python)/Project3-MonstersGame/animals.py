#Rush Weigelt rw643 sec.063
#imports
from base_class import Enemy
#Cat enemy type. Used super from enemy and added the shield attribute
class feralCat(Enemy):
    def __init__(self):
        super().__init__('Feral Tuxedo Cat', 30, 10)
        self.shield = False
    def getDescription(self):
        return 'The Tuxedo Cat is soft and debonair.'
    #Now I realize this is extraneous, as the enemy baseclass should have this covered
    def getName(self):
        return self.name
    #most basic attack; low damage.
    def basicAttack(self, other):
        other.doDamage(10)
    def basicName(self):
        return 'Scratch'
    #secondary attack; higher damage.
    def secondaryAttack(self, other):
        other.doDamage(15)
    def secondaryName(self):
        return 'Sneaky Pounce'
    #a healing action.
    def triAttack(self):
        self.health += 10
        print(self.name + ' used Cuddle Attack to heal herself 10 health points.')
    def triName(self):
        return 'Cuddle Attack'
#Dog enemy, instanced same as above from enemy class, but with different attributes
class dog(Enemy):
    def __init__(self):
        super().__init__('Ferocious Pug', 25, 10)
        self.shield = False
    def getDescription(self):
        return 'The Ferocious Pug is silky and spontaneous.'
    def getName(self):
        return self.name
    #basic attack; low damage
    def basicAttack(self, other):
        other.doDamage(5)
    def basicName(self):
        return 'Bark'
    #secondary attack; higher damage
    def secondaryAttack(self, other):
        other.doDamage(20)
    def secondaryName(self):
        return 'Fart'
    #third action option; heals monster, including overhealing.
    def triAttack(self):
        self.health += 15
        print(self.name + ' used Snooze to heal herself 15 health points.')
    def triName(self):
        return 'Snooze'
#Third monster class, same as above.
class mouse(Enemy):
    def __init__(self):
        super().__init__('Pipsqueak the Mouse', 50, 10)
        self.shield = False
    def getDescription(self):
        return 'Pipsqueak Mouse is more than he seems.'
    def getName(self):
        return self.name
    #basic attack; higher damage
    def basicAttack(self, other):
        other.doDamage(20)
    def basicName(self):
        return 'Nibble'
    #secondary attack; lower damage
    def secondaryAttack(self, other):
        other.doDamage(5)
    def secondaryName(self):
        return 'Scuttle'
    #healing action option
    def triAttack(self):
        self.health += 10
        print(self.name + ' used Cheese Curd to heal herself 10 health points.')
    def triName(self):
        return 'Cheese Curd'
#Fourth and final monster class, instanced same as above, but again with different values.
class cow(Enemy):
    def __init__(self):
        super().__init__('Selma the Cow', 60, 10)
        self.shield = False
    def getDescription(self):
        return 'Selma is peaceful and elegant.'
    def getName(self):
        return self.name
    #basic attack; higher damage.
    def basicAttack(self, other):
        other.doDamage(20)
    def basicName(self):
        return 'Moo'
    #secondary attack; lower damage
    def secondaryAttack(self, other):
        other.doDamage(8)
    def secondaryName(self):
        return 'Poisonous Milk'
    #third action option, a large self heal (because cows are nurturing?)
    def triAttack(self):
        self.health += 15
        print(self.name+' used Nuturing Milk to heal herself 30 health points.')
    def triName(self):
        return 'Nurturing Milk'

