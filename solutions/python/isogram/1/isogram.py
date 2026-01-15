import re

def is_isogram(string):
    lowered = string.lower()
    regex = re.compile('[^a-z]')
    letters = regex.sub('', lowered)
    
    found = []
    for character in letters:
        if not character.isalpha():
            continue
            
        if character in found:
            return False
        else:
            found.append(character)

    return True
