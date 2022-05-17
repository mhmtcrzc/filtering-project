import sqlite3
from random import randint
from uuid import uuid4

DB_PATH = './okey.db'
TABLE_COUNT = 250

db_connection = sqlite3.connect(DB_PATH)
cursor = db_connection.cursor()

delete_query = 'DELETE FROM Tables'
cursor.execute(delete_query)

for i in range(TABLE_COUNT):
    unique_id = str(uuid4().hex)
    query_string = 'INSERT INTO Tables VALUES("{}", {}, {});'.format(unique_id,randint(200,5000),randint(0,7))
    cursor.execute(query_string)

db_connection.commit()
cursor.close()
db_connection.close()