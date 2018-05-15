# Rush Weigelt rw643 sec.#063

# imports
from socialite import Socialite
s = Socialite
# welcome
print('Welcome to CS 172: Socialite Homework')
num_socialites = input('How many Socialites do you want to create?\n')
# empty list and dictionary for name and URL index info
index_dict = {}
index_links = []
# a way to exit
while num_socialites != 'exit':
    # ensure user provides an INTEGER
    try:
        num_socialites = int(num_socialites)
        # count pages for iteration
        page_num = 1
        # loop for creating any number of 'Socialite Pages'
        while num_socialites > 0:
            # convert page number to string for printing
            page_num = str(page_num)
            print('Enter Data for Socialite #' + page_num + '\n')
            # six attribute aquisition and assignment
            # first name
            first_name = input('Enter First Name:\n')
            s.f = first_name
            # last name
            last_name = input('Enter Last Name:\n')
            s.l = last_name
            # user ID
            user_ID = input('Enter User ID:\n')
            s.u = user_ID
            # picture URL
            pic_url = input('Enter URL for Picture:\n')
            s.p = pic_url
            # web URL
            web_url = input('Enter URL for Website: \n')
            s.w = web_url
            # web Description
            web_descript = input('Enter Website Description:\n')
            s.d = web_descript
            # a break and print to confirm data entry was correct
            print('SOCIALITE CREATED, DATA BELOW FOR CONFIRMATION')
            print(s.__str__(s))
            # create and write the html pages for each user
            html = open(user_ID + '.html', 'w')
            page_content = s.html(s)
            html.write(page_content)
            # adding info to index dict, to help index later
            name = first_name + ' ' + last_name
            socialite_html = user_ID + '.html'
            index_dict[name] = socialite_html
            #HTML code for any number of references on index page
            index = '        <p><a href="' + socialite_html + '">' + name + '</a></p>\n'
            index_links.append(index)
            # counting our loop
            page_num = int(page_num)
            page_num += 1
            num_socialites -= 1
        # first part of the index html
        index_top = '<html> \n    <head>\n        <title>List of Socialite Profiles</title>\n    </head>\n    <body>\n        ' \
                    '<h2>List of Socialite Profiles</h2>\n'
        # last part of the index html
        index_bottom = '    </body>\n</html>'
        # create index html, combine all parts
        index_total = len(index_links)
        index_start = index_total-index_total
        # while index_start <= index_total:
        index_first = 'index_links[a]+'*index_total
        # loop to combine every created index link from the dictionary in form index_links[0]+index_links[1]+ etc
        while index_start < index_total:
            index_start = str(index_start)
            index_first = index_first.replace('a', index_start, 1)
            index_start = int(index_start)
            index_start += 1
        # chop off the one excess '+' sign so the code runs correctly
        index_middle = index_first[0:-1]
        # combine all parts of HTML for index page, create the page and write to it.
        index_content = index_top + eval(index_middle) + index_bottom
        index_content = str(index_content)
        index_html = open('index.html', 'w')
        index_html.write(index_content)
        #close our open files
        index_html.close()
        html.close()

    # value error
    except ValueError as e:
        print('Invalid input, we need an interger. Else, type "exit" to exit program')
    num_socialites = input('Enter an integer please (or type "exit" to quit): \n')
