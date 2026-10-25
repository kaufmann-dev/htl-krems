#!/usr/bin/env python
# coding: utf-8

# In[2]:


import re


# In[2]:


# 3.1 #

p = re.compile("[0-9]+\.[0-9][0-9][€$]")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 5 Semmeln habe ich 3.90$ bezahlt."))
print("\n")

p = re.compile(" [0-9] ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt."))


# In[3]:


# 3.2 #

p = re.compile("[0-9][0-9][0-9]")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt."))
print("Es spricht nur 3 Zahlen welche aneinanderschließen an.\n")

p = re.compile(" [0-9]+ ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 


# In[4]:


# 3.3 #

p = re.compile(" [0-9]+[..][0-9]{2}[E$]? ")
print(p.findall("Für 5 Semmeln habe ich 3.90€ bezahlt."))
print(p.findall("Für 15 Semmeln habe ich 19.50$ bezahlt."))
print(p.findall("Für 150 Semmeln habe ich 190.50$ bezahlt.")) 


# In[5]:


# 3.4 #

# Match sucht nach dem ersten Auftreten der Reglar Expression in einem String
p = re.compile("Telefonnummer")
match = p.search("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
# Durchsuch ganze Zeichenkette
print(match.span())
print(match.start())
print(match.end())
print(match.group())

# Gibt einen Iterator zurück der alle Matches in einem String beinhaltet
matches = p.finditer("Meine Telefonnummer ist 0664 555 0 123. Ruf schnell an!")
for match in matches:
    print(match)


# In[4]:


# 3.6 #

import urllib.request as urllib2
from bs4 import BeautifulSoup 
import pandas as pd

p = re.compile("[a-z]\.?[a-z]+@[a-z]+\.at")
# p = re.compile("[a-zA-Z0-9]+@[a-zA-Z0-9]+.[a-zA-Z0-9]+")

response = urllib2.urlopen('https://www.htlkrems.ac.at')
html_doc = response.read()
soup = BeautifulSoup(html_doc, 'html.parser')
soup_str = str(soup)
emails = p.findall(soup_str)

df = pd.DataFrame(data=emails)
df.to_csv('emails.csv', index=False, header=False)


# In[6]:


# 3.7 #

response = urllib2.urlopen('https://www.imdb.com/chart/top?ref_=nv_mv_250_6:')
html_doc = response.read()
soup = BeautifulSoup(html_doc, 'html.parser')
tras = soup.find_all('tr')[1:]

t, y, r = [], [], []

for aa in tras:
    bruh = aa.find_all("a")
    t.append(bruh[1].string)
    
    bre = aa.find_all("span")
    y.append(bre[5].string[1:5])
    
    bro = aa.find("strong")
    r.append(bro.string)

s_t = pd.Series(t)
s_y = pd.Series(y)
s_r = pd.Series(r)

df = pd.concat([s_t, s_y, s_r], axis=1)
df.columns = ["Titel", "Jahr", "Rating"]
df


# In[ ]:




