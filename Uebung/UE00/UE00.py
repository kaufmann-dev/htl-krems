#!/usr/bin/env python
# coding: utf-8

# In[29]:


# 0.1
import pandas as pd
data = pd.read_csv("movie.csv")
print("Rows:",data.shape[0],"\nColumns:",data.shape[1])


# In[3]:


# 0.2
data.head()


# In[4]:


# 0.3
x = data["movie_title"]
type(x)


# In[5]:


# 0.4
data["has_seen"] = 0
data.iloc[:,-1].head()


# In[24]:


# 0.5
# a
data['director_actor_facebook_likes'] = data['director_facebook_likes'] + data['actor_1_facebook_likes'] + data['actor_2_facebook_likes'] + data['actor_3_facebook_likes']
print(data['director_actor_facebook_likes'].head(),"\n")

# b
print("Python cannot add number values and NaN values\n")

# c
print(data['director_actor_facebook_likes'].isnull().sum())
data['director_actor_facebook_likes'] = data['director_actor_facebook_likes'].fillna(0)
print(data['director_actor_facebook_likes'].isnull().sum())


# In[25]:


# 0.6
print("Zuerst den Median-Wert finden und dann überprüfen ob das Budget über/unter diesem liegt")


# In[ ]:




