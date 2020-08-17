package com.ankamagames.dofus.network.types.game.data.items.effects
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectEffectDate extends ObjectEffect implements INetworkType
   {
      
      public static const protocolId:uint = 72;
       
      
      public var year:uint = 0;
      
      public var month:uint = 0;
      
      public var day:uint = 0;
      
      public var hour:uint = 0;
      
      public var minute:uint = 0;
      
      public function ObjectEffectDate()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 72;
      }
      
      public function initObjectEffectDate(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0) : ObjectEffectDate
      {
         super.initObjectEffect(param1);
         this.year = param2;
         this.month = param3;
         this.day = param4;
         this.hour = param5;
         this.minute = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.year = 0;
         this.month = 0;
         this.day = 0;
         this.hour = 0;
         this.minute = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectEffectDate(param1);
      }
      
      public function serializeAs_ObjectEffectDate(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectEffect(param1);
         if(this.year < 0)
         {
            throw new Error("Forbidden value (" + this.year + ") on element year.");
         }
         param1.writeVarShort(this.year);
         if(this.month < 0)
         {
            throw new Error("Forbidden value (" + this.month + ") on element month.");
         }
         param1.writeByte(this.month);
         if(this.day < 0)
         {
            throw new Error("Forbidden value (" + this.day + ") on element day.");
         }
         param1.writeByte(this.day);
         if(this.hour < 0)
         {
            throw new Error("Forbidden value (" + this.hour + ") on element hour.");
         }
         param1.writeByte(this.hour);
         if(this.minute < 0)
         {
            throw new Error("Forbidden value (" + this.minute + ") on element minute.");
         }
         param1.writeByte(this.minute);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectEffectDate(param1);
      }
      
      public function deserializeAs_ObjectEffectDate(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._yearFunc(param1);
         this._monthFunc(param1);
         this._dayFunc(param1);
         this._hourFunc(param1);
         this._minuteFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectEffectDate(param1);
      }
      
      public function deserializeAsyncAs_ObjectEffectDate(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._yearFunc);
         param1.addChild(this._monthFunc);
         param1.addChild(this._dayFunc);
         param1.addChild(this._hourFunc);
         param1.addChild(this._minuteFunc);
      }
      
      private function _yearFunc(param1:ICustomDataInput) : void
      {
         this.year = param1.readVarUhShort();
         if(this.year < 0)
         {
            throw new Error("Forbidden value (" + this.year + ") on element of ObjectEffectDate.year.");
         }
      }
      
      private function _monthFunc(param1:ICustomDataInput) : void
      {
         this.month = param1.readByte();
         if(this.month < 0)
         {
            throw new Error("Forbidden value (" + this.month + ") on element of ObjectEffectDate.month.");
         }
      }
      
      private function _dayFunc(param1:ICustomDataInput) : void
      {
         this.day = param1.readByte();
         if(this.day < 0)
         {
            throw new Error("Forbidden value (" + this.day + ") on element of ObjectEffectDate.day.");
         }
      }
      
      private function _hourFunc(param1:ICustomDataInput) : void
      {
         this.hour = param1.readByte();
         if(this.hour < 0)
         {
            throw new Error("Forbidden value (" + this.hour + ") on element of ObjectEffectDate.hour.");
         }
      }
      
      private function _minuteFunc(param1:ICustomDataInput) : void
      {
         this.minute = param1.readByte();
         if(this.minute < 0)
         {
            throw new Error("Forbidden value (" + this.minute + ") on element of ObjectEffectDate.minute.");
         }
      }
   }
}
