#Rush Weigelt rw643 sec063
#imports
from Node import Node
from DoublyLinkedList import DLL
import sys
#Opening print statement
print('Welcome to Linked List Tester')
#command options flush against screen
print("Commands: \nclear - Removes every value from the list. \nappend num - Add the given number to end of list."
      "\nprepend - Add given number to beginning of list. \ninsertAfter - Places num2 after first apperance of num 1."
      "\ndelete num - Deletes the first appearance of given number. \nexit - Exit's the program.")
#initialize our Doubly Linked List
LL = DLL([])
#take input, have exit function, reask question if improper command is given
user_in = input('command:\n')
#exit
while user_in != 'exit':
      #split list up by comma
      command = user_in.split(' ')
      #first command will be the word, so match input word to function
      if command[0] == 'append':
            #second command is our value for new node
            n = Node(command[1], None, None)
            #append it to the string
            LL.append(n.__str__())
            #print
            print('Current List: ' + LL.__str__())
            #ask again, until user types exit
            user_in = input('command:\n')
      #same comments from above apply for prepend
      elif command[0] == 'prepend':
            n = Node(command[1], None, None)
            LL.prepend(n.__str__())
            print('Current List: ' + LL.__str__())
            user_in = input('command:\n')
      #InsertAfter
      elif command[0] == 'insertAfter':
            #create a new node
            n = Node(command[2], None, None)
            #make the search entry look like it would in list ([x])
            z = '['+command[1]+']'
            #insert at number entered
            LL.insertAfter(z, n.__str__())
            #print
            print('Current List: ' + LL.__str__())
            #reask
            user_in = input('command:\n')
      #clear list simply clears list
      elif command[0] == 'clear':
            LL.clear()
            print('Current List: ' + LL.__str__())
            user_in = input('command:\n')
      #delete a node
      elif command[0] == 'delete':
            #value of node we're deleting
            z = '['+command[1]+']'
            #delete
            LL.delete(z)
            #reprint
            print('Current List: ' + LL.__str__())
            #reask
            user_in = input('command:\n')
      else:
            user_in = input('command:\n')
#quit statement
if user_in == 'exit':
      print('Thank you for using the linked list tester. Good bye')
      sys.exit(0)






print(user_in.split(' '))
print(command)
print(LL.__str__())