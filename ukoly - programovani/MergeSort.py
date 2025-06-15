import random
from time import time
INF = 1e20

def puleni(start, end):
    if start == end - 1:
        return [array[start]]
        
    pulka = int((start + end) / 2)
    a = puleni(start, pulka)
    b = puleni(pulka, end)
    a.append(INF)
    b.append(INF)
    spojeno = []
    i, j = 0, 0
    while i < len(a) - 1 or j < len(b) - 1:
        if a[i] < b[j]:
            spojeno.append(a[i])
            i += 1
        else:
            spojeno.append(b[j])
            j += 1

    return spojeno

def treteni(start, end):
    if start == end:
        return []
    if start == end - 1:
        return [array[start]]
        
    tretina = int((end - start) / 3 + start)
    dvetretiny = int((end - start) / 3 * 2 + start)
    
    a = treteni(start, tretina)
    b = treteni(tretina, dvetretiny)
    c = treteni(dvetretiny, end)
    a.append(INF)
    b.append(INF)
    c.append(INF)
    spojeno = []
    i, j, k = 0, 0, 0
    while i < len(a) - 1 or j < len(b) - 1 or k < len(c) - 1:
        if (a[i] < b[j]) and (a[i] < c[k]):
            spojeno.append(a[i])
            i += 1
        elif (b[j] < a[i]) and (b[j] < c[k]):
            spojeno.append(b[j])
            j += 1
        elif (a[i] == b[j]) and (a[i] < c[k]):
            spojeno.append(a[i])
            i += 1
        else:
            spojeno.append(c[k])
            k += 1

    return spojeno

N = 10000
opakovani = 1000
print(f"Benchmarkt pro listy dlouhé {N} se {opakovani} opakováními")
sTime = time()
for i in range(opakovani):
    array = [random.randint(1, 100000000) for i in range(N)]
    puleni(0, len(array))
eTime = time()
print(f"puleni trvalo {eTime - sTime} s")

sTime = time()
for i in range(opakovani):
    array = [random.randint(1, 100000000) for i in range(N)]
    treteni(0, len(array))
eTime = time()
print(f"treteni trvalo {eTime - sTime} s")