#!/usr/bin/env python
# coding: utf-8

# In[2]:


import pandas as pd


# In[3]:


# 3.1 #

tweets=[ 
    'This is introduction to NLP', 
    'It is likely to be useful, to people ', 
    'Machine learning is the new electrcity', 
    'There would be less hype around AI and more action going forward', 
    'python is the best tool!','R is good langauage', 
    'I like this book','I want more books like this' 
]

# 3.2 #

tweetsdf = pd.DataFrame()
tweetsdf['tweets'] = tweets
tweetsdf['tweets'] = tweetsdf['tweets'].str.lower()
display(tweetsdf.head(7))

# 3.3 #

tweetsdf['tweets'] = tweetsdf['tweets'].str.replace('[.,!?;]','', regex=True)
tweetsdf.head(7)


# In[5]:


import nltk
from nltk.tokenize import word_tokenize 
#nltk.download()
text="Hello there! Welcome to the programming world."
print(word_tokenize(text),"\n")
print(text.split())
print("\nSplit does not seperate commas, points and other special characters which are not seperated from a word.")


# In[6]:


# 3.4 #

from nltk.tokenize import sent_tokenize 
 
text="This is introduction to NLP. It is likely to be useful, to people." 
print(sent_tokenize(text))


# In[7]:


from nltk.tokenize import WordPunctTokenizer 
 
text="We're moving to N.Y.!" 
Tokenizer=WordPunctTokenizer() 
print(Tokenizer.tokenize(text))


# In[8]:


from nltk.tokenize import RegexpTokenizer 
 
text="We're moving to N.Y.!" 
tokenizer = RegexpTokenizer(r"\w+") 
print(tokenizer.tokenize(text))


# In[32]:


# 3.5 #

from nltk.tokenize import RegexpTokenizer
Tokenizer=RegexpTokenizer(r"\w+") 

tweetsTokenized = pd.DataFrame()
tweetsTokenized["tweets"] = tweets
tweetsTokenized["tweets"] = tweetsTokenized["tweets"].str.lower()
bru = []
for bruh in tweetsTokenized["tweets"]:
    bru.append(Tokenizer.tokenize(bruh))
tweetsTokenized["tokenized"] = bru

#print(Tokenizer.tokenize(str(tweetsTokenized["tweets"])))
display(tweetsTokenized.head())


# In[43]:


# 3.6 #

from nltk.tokenize import WordPunctTokenizer 
from nltk.tokenize import RegexpTokenizer 
Tokenizer=RegexpTokenizer(r"\w+") 
Tokenizer=WordPunctTokenizer() 

with open ("dataScientistJobDesc.txt", "r") as txt:
    data=txt.read()
    print(len(word_tokenize(data)))
    safu=[]
    for bratan in word_tokenize(data):
        if not bratan in safu:
            safu.append(bratan)
    print(len(safu))
    

