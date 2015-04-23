using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
	class TimeController
	{
	
		protected int count;
		//the cycle interval in seconds
		protected double interval;
		protected double nextStop;

		//returns the current timestamp (in seconds)
		protected double getTimeNow()
		{
			//Find unix timestamp (seconds since 01/01/1970)
			long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
			ticks /= 10000000; //Convert windows ticks to seconds            
			return ticks;
		}

		//returns the current timestamp (in seconds)
		public static double timeStamp()
		{
			//Find unix timestamp (seconds since 01/01/1970)
			long ticks = DateTime.UtcNow.Ticks - DateTime.Parse("01/01/1970 00:00:00").Ticks;
			ticks /= 10000000; //Convert windows ticks to seconds            
			return ticks;
		}


		protected bool cycleEnded() 
		{
			if (nextStop < getTimeNow())
			{
				//next stop is a previous time than now, cycle has ended
				//recalculate the next stop
				calcNextStop();
				count++;
				return true;
			}
			else
			{
				//cycle has not yet ended
				return false;
			}
		}

		public double timeInterval 
		{
			get
			{
				return interval;				
			}

			set
			{
				interval = value;
				calcNextStop();
			}
		}

		public int cyclesCount
		{
			get { return count; }
		}

		public double now
		{
			get { return getTimeNow(); }
		}

		public bool isCycleDone 
		{ 
			get { return cycleEnded(); }
		}

		//constructor creates and starts the timer
		public TimeController()
		{
			//default interval
			interval = 10;
			count = 0;
			nextStop = 0;
			calcNextStop();        
		}

		//constructor creates and starts the timer
		//defines the time interval
		//the delay flag will determine if we wait for the next stop
		//or starts inmediatly
		public TimeController(double timeInterval, bool delay)
		{
			interval = timeInterval;
			count = 0;
			nextStop = 0;
			if (delay)
			{
				calcNextStop();
			}        
		}

		//calculates the next stop as the next
		//time the time interval is done
		public void calcNextStop() 
		{
			double now = getTimeNow();
			nextStop = now + interval;        
		}

	}
}
