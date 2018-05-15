#Rush Weigelt rw643 sec.#063

class Socialite:
    def __int__(self):
        '''Initialize each field as empty strings'''
        self.l = ''
        self.f = ''
        self.p = ''
        self.w = ''
        self.d = ''
        self.u = ''

    def __str__(self):
        '''Format and print the string as desired'''
        return 'Name: ' + str(self.f) + ' ' + str(self.l)+'\n' + \
        'User ID: ' + str(self.u) + '\n' + \
        'Picture: ' + str(self.p) + '\n' + \
        'Website: ' + str(self.w) + '\n' + \
        'Website Description: ' + str(self.d) + '\n'

    def html(self):
        '''Format and print html version of user entries'''
        return '<html>' + '\n' + '    ' + '<head>' + '\n' + '        ' + '<title>' + str(self.f)+' '+str(self.l)+ \
        "'s Socialite Page</title>" + '\n' + '    ' + '</head>' + '\n' + '    ' + '<body>' + '\n' +  '        ' + \
        '<img width="400px" src=' + '"' + str(self.p) + '"' + ' alt="' + str(self.f) + ' ' + str(self.l) +"'s Picture" \
        + '"' + ' align="RIGHT" />' + '\n' + '        ' +'<h1>' + str(self.u) + '</h1>' + '\n' + '        ' + '<h2>' + \
        str(self.f) + ' ' + str(self.l) + '</h2>' + '\n' + '        ' + '<hr />' + '\n' + '        ' + '<p>' + '\n' + \
        '            ' + str(self.f) + ' wants to share' + '\n' + '            ' + '<a href="' + str(self.w) + '" ' + \
        'target="_blank">' + '\n' + '            ' + str(self.d) + '</a>' + '\n' + '            ' + 'wih you:<br />' + \
        '\n' + '            ' + str(self.w) + '\n' + '        ' + '</p>' + '\n' + '    ' + '</body>' + '\n' + '</html>'

#mutator methods
    def setLastName(self, l):
        self.l = l

    def setFirstName(self, f):
        self.f = f

    def setPicture(self, p):
        self.p = p

    def setWebsite(self, w):
        self.w = w

    def setDescription(self, d):
        self.d = d

    def setUserID(self, u):
        self.u = u

#accessor methods
    def getLastName(self):
        return self.l

    def getFirstName(self):
        return self.f

    def getPicture(self):
        return self.p

    def getWebsite(self):
        return self.w

    def getDescription(self):
        return self.d

    def getUserID(self):
        return self.u
