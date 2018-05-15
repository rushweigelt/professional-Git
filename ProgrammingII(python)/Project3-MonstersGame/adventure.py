#Rush Weigelt rw643 sec063
#imports
from hero import hero
from animals import *
import sys
import random
#ask player's action, loop back if it isn't 1 of 5 options (sword, shield, potion, fireball, exit).
def ask_action():
    attack = input("What would you like to do?\nsword, shield, fireball, potion, exit: \n")
    boo = True
    while boo == True:
        if attack == 'sword':
            boo = False
        elif attack == 'shield':
            boo = False
        elif attack == 'fireball':
            boo = False
        elif attack == 'potion':
            boo = False
        elif attack == 'exit':
            print('Thank you, I hope you enjoyed the adventure!\n')
            sys.exit(0)
        else:
            boo = True
            attack = input("What would you like to do?\nsword, shield, fireball, potion, exit: \n")
    return attack
#ask how many monsters the player would like to battle. Only accepts an integer or exit as input, otherwise loops back for a new entry.
def ask_mon():
    boo = True
    while boo == True:
        try:
            user_num = input('How many monsters would you like to fight? \n')
            if user_num == 'exit':
                print('Thank you, I hope you enjoyed the adventure!\n')
                sys.exit(0)
            user_num = int(user_num)
            return user_num
        except ValueError:
            print('Value error, please enter an integer\n')
# the actual battle. Monster attacks first, since it is on the offensive.
def battle(hero, m1):
    print(m1.getName() + ' attacks ' + hero.getName() +'\n')
    timeout = False
    attacker = m1
    defender = hero
    #monster attacker-randomly decide between 1 of 3 actions. Actions 1 and 2 deal damage, while action 3 heals enemy.
    while (hero.getHealth() > 0 and m1.getHealth() > 0 and attacker == m1) or (hero.getHealth() > 0 and m1.getHealth() > 0 and not timeout and attacker == hero):
        while (hero.getHealth() > 0 and m1.getHealth()>0 and attacker == m1):
            initial_health = defender.getHealth()
            mon_attack = random.randint(1,3)
            if mon_attack == 1:
                attacker.basicAttack(defender)
                print_results(attacker, defender, attacker.basicName(), initial_health - defender.getHealth())
            elif mon_attack == 2:
                attacker.secondaryAttack(defender)
            #text for healing is printed from the enemy class, rather than here.
            elif mon_attack == 3:
                attacker.triAttack()
            #switch roles, so player now becomes attacker, and monster is on defense.
            tmp = attacker
            attacker = defender
            defender = tmp
        #a status update that provides the player's health, the monster's health, and the remaining items of the player.
        print(m1.getName()+ "'s Health: "+ str(m1.getHealth()))
        print(hero.getName() + "'s Health: " + str(hero.getHealth()) + '/100 health.\n')
        print(hero.getItems())
        #player attack loop. Directions for each valid input of action from the user with the proper corresponding outcome.
        while (hero.getHealth() > 0 and m1.getHealth() > 0 and attacker == hero):
            initial_health = defender.getHealth()
            boo = True
            move = ask_action()
            while boo == True:
                if move == 'sword':
                    hero.basicAttack(defender)
                    print_results(attacker, defender, attacker.basicName(), initial_health - defender.getHealth())
                    boo = False
                elif move == 'shield':
                    hero.defenseAttack(defender)
                    print('Used shield, reduces next attack by 50%\n')
                    boo = False
                elif move == 'fireball':
                    hero.secondaryAttack(defender)
                    print_results(attacker, defender, attacker.secondaryName(), initial_health - defender.getHealth())
                    boo = False
                elif move == 'potion':
                    hero.potion()
                    boo = False
                else:
                    boo = True
            #switch roles
            tmp = attacker
            attacker = defender
            defender = tmp
        # Determine Results of the battle.
        if hero.getHealth() < 1 and m1.getHealth() < 1:
            print("Both Monsters are unconscious the match is a tie\n")
            return None
        if hero.getHealth() < 1:
            print(hero.getName() + " fainted, all is lost and the game is over!\n")
            sys.exit(0)
        if m1.getHealth() < 1:
            print(hero.getName() + " defeated " + m1.getName() + '!\n')
            return hero
#print results of each move, including who is attacking whom, with what attack, and how much damage (or healing) was done.
def print_results(attacker, defender, attack, hchange):
    res = attacker.getName() + " used " + attack
    res += " on " + defender.getName() + "\n"
    res += "The attack did " + str(hchange) + " damage.\n"
    print(res)
if __name__=="__main__":
    #The start of our adventure, really.
    print('Welcome to The Ultimate Adventure Game\n')
    #Asks for name, if the user types exit we exit properly with a nice thank you message.
    name = input("First, what is your hero's name?\n")
    if name == 'exit':
        print('Well that was quick, but thanks for playing. \n')
        sys.exit(0)
    #instance a hero with the player's desired name.
    player = hero(name)
    #Take the number of monsters to fight provided by the user and create a list of instanced monsters to fight.
    monster_number = ask_mon()
    monsters = []
    while monster_number > 0:
        monster_lib = [mouse(), feralCat(), cow(), dog()]
        temp = random.randint(0,3)
        monster = monster_lib[temp]
        monsters.append(monster)
        monster_number -= 1
    #loop so each monster is fought and if defeated, iterate to the next monster.
    while len(monsters) > 0:
        fight = monsters[0]
        battle(player, fight)
        monsters.pop(0)
    #Final print screen for a victorious player.
    print(name + ' defeated all of the monsters and saved the prince from danger!\n')


