#!/usr/bin/env python
# coding: utf-8

# In[1]:


import PyPDF2 as pypdf


# In[2]:


## 2.1


# In[8]:


with open('schachnovelle.pdf', 'rb') as pdf:
    reader = pypdf.PdfFileReader(pdf)
    #print(f"Author:     {reader.documentInfo.author}\nProducer:   {getattr(reader.documentInfo, 'producer')}\nTitle:      {getattr(reader.documentInfo, 'title')}")
    print(f"{'Author:' : <12}{reader.documentInfo.author}\n{'Producer:' : <12}{reader.documentInfo.producer}\n{'Title:' : <12}{reader.documentInfo.title}")


# In[14]:


## 2.2


# In[15]:


with open('schachnovelle.pdf', 'rb') as pdf:
    reader = pypdf.PdfFileReader(pdf)
    print(reader.getPage(0).extract_text())


# In[16]:


with open('schachnovelle.pdf', 'rb') as pdf:
    reader = pypdf.PdfFileReader(pdf)
    text = ""
    for page in reader.pages:
        text += page.extract_text() + "\n"
    print(text)


# In[17]:


with open('schachnovelle.pdf', 'rb') as pdf:
    reader = pypdf.PdfFileReader(pdf)
    text = []
    for page in reader.pages:
        text.append(page.extract_text())
    for listitem in text:
        print(listitem)


# In[18]:


## docx


# In[19]:


from docx import Document
from docx.shared import Inches 


# In[20]:


document = Document()
document.add_heading('Document Title', 0)
p = document.add_paragraph('A plain paragraph having some ')
p.add_run('bold').bold = True
p.add_run(' and some ')
p.add_run('italic.').italic = True
document.add_heading('Heading, level 1', level=1)
document.add_paragraph('Intense quote', style='Intense Quote')
document.add_paragraph(
 'first item in unordered list', style='List Bullet'
)
document.add_paragraph(
 'first item in ordered list', style='List Number'
)
document.add_picture('terry.jpg', width=Inches(1.25))
records = (
 (3, '101', 'Spam'),
 (7, '422', 'Eggs'),
 (4, '631', 'Spam, spam, eggs, and spam')
)
table = document.add_table(rows=1, cols=3)
hdr_cells = table.rows[0].cells
hdr_cells[0].text = 'Qty'
hdr_cells[1].text = 'Id'
hdr_cells[2].text = 'Desc'
for qty, id, desc in records:
    row_cells = table.add_row().cells
    row_cells[0].text = str(qty)
    row_cells[1].text = id
    row_cells[2].text = desc
document.add_page_break()
document.save('demo.docx')


# In[ ]:


## html


# In[26]:


import urllib.request as urllib2
from bs4 import BeautifulSoup 


# In[27]:


# Website laden
response = urllib2.urlopen('https://www.htlkrems.ac.at')
html_doc = response.read()

# Das BeautifulSoup Object soup repräsentiert das „geparste“ HTML-Dokument
soup = BeautifulSoup(html_doc, 'html.parser')

# Das „geparste“ HTML-Dokument formatieren, sodass jeder Tag bzw. Textblock
# in einer separaten Zeile ausgegeben wird
strhtm = soup.prettify()

# Ein paar Zeilen ausgeben
print (strhtm[:1000])


# In[28]:


print(soup.title)
print(soup.title.string) 


# In[1]:


## 2.3


# In[39]:


for aa in soup.find_all('a'):
    print(aa.string) 


# In[36]:


print(len(allas))


# In[ ]:




