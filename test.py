def myFunc(a1):
    upper_letters = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]
    lower_letters = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]

    for i in range(len(a1)):
        if i % 2 == 0:
            if a1[i] not in lower_letters:
                return False
        elif i % 2 == 1:
            if a1[i] not in upper_letters:
                return False
    return True

print(myFunc("aNiMaLel")) # True