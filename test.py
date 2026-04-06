def get_pangram(a1):
    pangram = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"]
    new_a1 = a1[0].lower()
    checking = []
    for i in new_a1:
        if i in pangram:
            if i not in checking:
                checking.append(i)
    
    if len(checking) == len(pangram):
        print("It is a Pangram")
    else:
        print("It is not a Pangram")
    
get_pangram(["The quick brown fox  over the lazy dog"])