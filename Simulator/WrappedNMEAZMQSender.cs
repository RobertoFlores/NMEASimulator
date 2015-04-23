using System;
using System.IO;
using Crypto;
using System.Runtime.Serialization;
using zeroMQTools;
using NMEAUtils;

namespace zeroMQTools
{
    public class WrappedNMEAZMQSender : ZMQSender
    {
        protected byte[] baseStationData;

	    public WrappedNMEAZMQSender()
        {
            //generate default values
            this.IpAddress = "127.0.0.1";
            this.Port = 13000;        
        }

	    public WrappedNMEAZMQSender(string server, int port)
        {
            this.IpAddress = server;
            this.Port = port;        
        }

        //receives a base station object and serializes it and encrypts it
        //so it can be used in the future in the sending method
	    public bool setBaseStation(DataAcquisitionStation bs)
        {
	        try
	        {
		        //formatter who serializes, and stream for serialized data			
		        Stream bsSerialized = Serialize(bs);

		        //create encryptor
		        RainDollController rainDoll = new RainDollController();
		        //encrypt serialized object								
		        baseStationData = rainDoll.Encrypt(bsSerialized);
	        }
	        catch //pokemon exception handling
	        {
		        return false;
	        }

	        return true;
        }

        //sends a decoded message (target) using the TCP socket
	    public bool SendTarget(decodedMessage target)
        {
	        try
	        {
		        //formatter who serializes, and stream for serialized data		
		        Stream msSerialized = Serialize(target);

		        //create encryptor
		        RainDollController rainDoll = new RainDollController();
		        //encrypt serialized object								
		        byte[] encrypted = rainDoll.Encrypt(msSerialized);		

		        //put the serialized data into a transporter 
		        SerialDataTransporter transporter = new SerialDataTransporter();
		        transporter.data = encrypted;
		        transporter.bsdata = baseStationData;

		        //send the transporter to the write buffer
		        SendObject(transporter);
	        }
	        catch(SerializationException e) 
	        {
		        return false;
	        }
	        catch //pokemon exception handling
	        {
		        return false;
	        }

	        return true;
        }

        //sends a decoded message (target) and a base station objects using the TCP socket
	    public bool SendTarget(decodedMessage target, DataAcquisitionStation bs)
        {
	        try
	        {
		        //formatter who serializes, and stream for serialized data		
		        Stream msSerialized = Serialize(target);
		        Stream bsSerialized = Serialize(bs);

		        //create encryptor
		        RainDollController rainDoll = new RainDollController();
		        //encrypt serialized object								
		        byte[] encrypted = rainDoll.Encrypt(msSerialized);	
		        byte[] encryptedBS = rainDoll.Encrypt(bsSerialized);

		        //put the serialized data into a transporter 
		        SerialDataTransporter transporter = new SerialDataTransporter();
		        transporter.data = encrypted;
		        transporter.bsdata = encryptedBS;

		        //send the transporter to the write buffer
		        SendObject(transporter);
	        }
	        catch(SerializationException e) 
	        {
		        return false;
	        }
	        catch //pokemon exception handling
	        {
		        return false;
	        }

	        return true;
        }

        //receives a base station object and serializes it 
        //unlike the previous method this one does not encrypt the serial object
	    bool setPlainBaseStation(DataAcquisitionStation bs)
        {
	        try
	        {
		        //formatter who serializes, and stream for serialized data			
		        Stream bsSerialized = Serialize(bs);
		        //set the serial object as the object base station
		        baseStationData = streamToBytes(bsSerialized);
	        }
	        catch //pokemon exception handling
	        {
		        return false;
	        }

	        return true;
        }

        //sends a decoded message (target) using ZMQ 
        //this is the non-decrypting version of SendTarget method
	    bool SendPlainTarget(decodedMessage target)
        {
	        try
	        {
		        //formatter who serializes, and stream for serialized data		
		        Stream msSerialized = Serialize(target);

		        //transform the serialized data to a byte array
		        byte[] serialObj = streamToBytes(msSerialized);	

		        //put the serialized data into a transporter 
		        SerialDataTransporter transporter = new SerialDataTransporter();
		        transporter.data = serialObj;
		        transporter.bsdata = baseStationData;

		        //send the transporter to the write buffer
		        SendObject(transporter);
	        }
	        catch(SerializationException e) 
	        {
		        return false;
	        }
	        catch //pokemon exception handling
	        {
		        return false;
	        }

	        return true;
        }

    }
}
