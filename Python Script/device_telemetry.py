
import paho.mqtt.client as mqtt #mqtt library
import random as random
import json
import time
from datetime import datetime
import pandas as pd

path_raw=r"C:\Users\Aiman Fakhrullah\Documents\Datalytica\ProjectPOC_Data\raw_maintenance.csv"
ACCESS_TOKEN_RAW='X14tnsYnWYVpqulgbISs'#Token of your device

path_refined=r"C:\Users\Aiman Fakhrullah\Documents\Datalytica\ProjectPOC_Data\refined_maintenance.csv"
ACCESS_TOKEN_REFINED='Yz5bDJ0LAY4UOTmnxrLh'#Token of your device

path_a=r"C:\Users\Aiman Fakhrullah\Documents\Datalytica\ProjectPOC_Data\machine_a.csv"
ACCESS_TOKEN_A='bh0hgMgxd0jf2mWzSDdD'#Token of your device

path_b=r"C:\Users\Aiman Fakhrullah\Documents\Datalytica\ProjectPOC_Data\machine_b.csv"
ACCESS_TOKEN_B='gCWTusIVXUgPfEHH3YmJ'#Token of your device

#broker="192.168.50.5"  # Home network
broker="192.168.0.137"   			    #host name
port=1883 					    #data listening port


client_raw= mqtt.Client("client_raw")    #create client object & assign function to callback
client_raw.username_pw_set(ACCESS_TOKEN_RAW,"")#access token from thingsboard device
client_raw.connect(broker,port,keepalive=60)#establish connection
print("connection to raw data client success")
d_raw=pd.read_csv(path_raw)
length_raw=len(d_raw)

client_refined= mqtt.Client("client_refined")    #create client object & assign function to callback
client_refined.username_pw_set(ACCESS_TOKEN_REFINED,"")#access token from thingsboard device
client_refined.connect(broker,port,keepalive=60)#establish connection
print("connection to refined data client sucess")
d_refined=pd.read_csv(path_refined)
length_refined=len(d_refined)

client_a= mqtt.Client("client_a")    #create client object & assign function to callback
client_a.username_pw_set(ACCESS_TOKEN_A,"")#access token from thingsboard device
client_a.connect(broker,port,keepalive=60)#establish connection
print("connection to a data client sucess")
d_a=pd.read_csv(path_a)
length_a=len(d_a)

client_b= mqtt.Client("client_b")    #create client object & assign function to callback
client_b.username_pw_set(ACCESS_TOKEN_B,"")#access token from thingsboard device
client_b.connect(broker,port,keepalive=60)#establish connection
print("connection to b data client sucess")
d_b=pd.read_csv(path_b)
length_b=len(d_b)

i=0
while True:
    data_raw=dict()
    data_raw["UDI"]=str(d_raw["UDI"][i])
    data_raw["ProductID"]=d_raw["ProductID"][i]
    data_raw["ProductType"]=d_raw["ProductType"][i]
    data_raw["AirTemp"]=d_raw["AirTemp"][i]
    data_raw["ProcessTemp"]=str(d_raw["ProcessTemp"][i])
    data_raw["RPM"]=str(d_raw["RPM"][i])
    data_raw["Torque"]=str(d_raw["Torque"][i])
    data_raw["ToolWear"]=str(d_raw["ToolWear"][i])
    data_raw["Target"]=str(d_raw["Target"][i])
    data_raw["FailureType"]=d_raw["FailureType"][i]
    data_out_raw=json.dumps(data_raw)
    

    data_refined=dict()
    data_refined["UDI"]=str(d_refined["UDI"][i])
    data_refined["ProductID"]=d_refined["ProductID"][i]
    data_refined["ProductType"]=d_refined["ProductType"][i]
    data_refined["AirTemp"]=d_refined["AirTemp"][i]
    data_refined["ProcessTemp"]=str(d_refined["ProcessTemp"][i])
    data_refined["TempDiff"]=str(d_refined["TempDifference"][i])
    data_refined["RPM"]=str(d_refined["RPM"][i])
    data_refined["RPS"]=str(d_refined["RotationPerSeconds"][i])
    data_refined["Torque"]=str(d_refined["Torque"][i])
    data_refined["Power"]=str(d_refined["Power"][i])
    data_refined["ToolWear"]=str(d_refined["ToolWear"][i])
    data_refined["Overstrain"]=str(d_refined["OverstrainReading"][i])
    data_refined["Target"]=str(d_refined["Target"][i])
    data_refined["FailureType"]=d_refined["FailureType"][i]
    data_out_refined=json.dumps(data_refined)

    data_a=dict()
    data_a["UDI"]=str(d_a["UDI"][i])
    data_a["ProductID"]=d_a["ProductID"][i]
    data_a["ProductType"]=d_a["ProductType"][i]
    data_a["AirTemp"]=d_a["AirTemp"][i]
    data_a["ProcessTemp"]=str(d_a["ProcessTemp"][i])
    data_a["TempDiff"]=str(d_a["TempDifference"][i])
    data_a["RPM"]=str(d_a["RPM"][i])
    data_a["RPS"]=str(d_a["RotationPerSeconds"][i])
    data_a["Torque"]=str(d_a["Torque"][i])
    data_a["Power"]=str(d_a["Power"][i])
    data_a["ToolWear"]=str(d_a["ToolWear"][i])
    data_a["Overstrain"]=str(d_a["OverstrainReading"][i])
    data_a["Target"]=str(d_a["Target"][i])
    data_a["FailureType"]=d_a["FailureType"][i]
    data_out_a=json.dumps(data_a)

    data_b=dict()
    data_b["UDI"]=str(d_b["UDI"][i])
    data_b["ProductID"]=d_b["ProductID"][i]
    data_b["ProductType"]=d_b["ProductType"][i]
    data_b["AirTemp"]=d_b["AirTemp"][i]
    data_b["ProcessTemp"]=str(d_b["ProcessTemp"][i])
    data_b["TempDiff"]=str(d_b["TempDifference"][i])
    data_b["RPM"]=str(d_b["RPM"][i])
    data_b["RPS"]=str(d_b["RotationPerSeconds"][i])
    data_b["Torque"]=str(d_b["Torque"][i])
    data_b["Power"]=str(d_b["Power"][i])
    data_b["ToolWear"]=str(d_b["ToolWear"][i])
    data_b["Overstrain"]=str(d_b["OverstrainReading"][i])
    data_b["Target"]=str(d_b["Target"][i])
    data_b["FailureType"]=d_b["FailureType"][i]
    data_out_b=json.dumps(data_b)

    #if data_raw["Target"] == "1" or data_refined["Target"] == "1":
    if data_raw["Target"] == "1" or data_refined["Target"] == "1" or data_a["Target"] == "1" or data_b["Target"] == "1":  
    #if data_a["Target"] == "1" or data_b["Target"] == "1":   
        if data_raw["Target"] == "1":
            ret= client_raw.publish("v1/devices/me/telemetry",data_out_raw,0) #topic-v1/devices/me/telemetry
            print(data_out_raw)
            print(data_refined["FailureType"] + "detected. Check your machine")
            input("Press Enter to continue process...")

        elif data_refined["Target"] == "1":
            ret= client_refined.publish("v1/devices/me/telemetry",data_out_refined,0) #topic-v1/devices/me/telemetry
            print(data_out_refined)
            print(data_refined["FailureType"] + " detected. Check your machine")
            input("Press Enter to continue process...")

        if data_a["Target"] == "1":
            ret= client_a.publish("v1/devices/me/telemetry",data_out_a,0) #topic-v1/devices/me/telemetry
            print(data_out_a)
            print(data_a["FailureType"] + "detected. Check your machine")
            input("Press Enter to continue process...")

        elif data_b["Target"] == "1":
            ret= client_b.publish("v1/devices/me/telemetry",data_out_b,0) #topic-v1/devices/me/telemetry
            print(data_out_b)
            print(data_b["FailureType"] + "detected. Check your machine")
            input("Press Enter to continue process...")
        
    
    else:
        ret= client_raw.publish("v1/devices/me/telemetry",data_out_raw,0) #topic-v1/devices/me/telemetry
        print(data_out_raw)

        ret= client_refined.publish("v1/devices/me/telemetry",data_out_refined,0) #topic-v1/devices/me/telemetry
        print(data_out_refined)

        ret= client_a.publish("v1/devices/me/telemetry",data_out_a,0) #topic-v1/devices/me/telemetry
        print(data_out_a)

        ret= client_b.publish("v1/devices/me/telemetry",data_out_b,0) #topic-v1/devices/me/telemetry
        print(data_out_b)

    time.sleep(1)
    i=i+1
    #if i==length_raw and i == length_refined:
    #if i==length_a and i == length_b:
    if i==length_raw and i == length_refined or i==length_a and i == length_b:
        i=0

