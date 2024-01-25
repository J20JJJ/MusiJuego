
from pytube import YouTube 
import os 
# Ruta al archivo
ruta = r"..\Assets\Canciones\Musica\cancion.txt"

# Abre el archivo en modo de lectura
with open(ruta, "r") as file:
    # Lee el contenido del archivo
    contenido = file.read()

    # Imprime el contenido del archivo
    print(contenido)

yt = YouTube(str(contenido)) 

video = yt.streams.filter(only_audio=True).first() 

print("Enter the destination (leave blank for current directory)") 
destination = str(r"..\Canciones\canciones")

out_file = video.download(output_path=destination) 

base, ext = os.path.splitext(out_file) 
new_file = base + '.mp3'
os.rename(out_file, new_file) 

print(yt.title + " has been successfully downloaded.")