package com.ankamagames.dofus.network.types.game.data.items.effects
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectEffectDuration extends ObjectEffect implements INetworkType
   {
      
      public static const protocolId:uint = 75;
       
      
      public var days:uint = 0;
      
      public var hours:uint = 0;
      
      public var minutes:uint = 0;
      
      public function ObjectEffectDuration()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 75;
      }
      
      public function initObjectEffectDuration(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0) : ObjectEffectDuration
      {
         super.initObjectEffect(param1);
         this.days = param2;
         this.hours = param3;
         this.minutes = param4;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.days = 0;
         this.hours = 0;
         this.minutes = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectEffectDuration(param1);
      }
      
      public function serializeAs_ObjectEffectDuration(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectEffect(param1);
         if(this.days < 0)
         {
            throw new Error("Forbidden value (" + this.days + ") on element days.");
         }
         param1.writeVarShort(this.days);
         if(this.hours < 0)
         {
            throw new Error("Forbidden value (" + this.hours + ") on element hours.");
         }
         param1.writeByte(this.hours);
         if(this.minutes < 0)
         {
            throw new Error("Forbidden value (" + this.minutes + ") on element minutes.");
         }
         param1.writeByte(this.minutes);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectEffectDuration(param1);
      }
      
      public function deserializeAs_ObjectEffectDuration(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._daysFunc(param1);
         this._hoursFunc(param1);
         this._minutesFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectEffectDuration(param1);
      }
      
      public function deserializeAsyncAs_ObjectEffectDuration(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._daysFunc);
         param1.addChild(this._hoursFunc);
         param1.addChild(this._minutesFunc);
      }
      
      private function _daysFunc(param1:ICustomDataInput) : void
      {
         this.days = param1.readVarUhShort();
         if(this.days < 0)
         {
            throw new Error("Forbidden value (" + this.days + ") on element of ObjectEffectDuration.days.");
         }
      }
      
      private function _hoursFunc(param1:ICustomDataInput) : void
      {
         this.hours = param1.readByte();
         if(this.hours < 0)
         {
            throw new Error("Forbidden value (" + this.hours + ") on element of ObjectEffectDuration.hours.");
         }
      }
      
      private function _minutesFunc(param1:ICustomDataInput) : void
      {
         this.minutes = param1.readByte();
         if(this.minutes < 0)
         {
            throw new Error("Forbidden value (" + this.minutes + ") on element of ObjectEffectDuration.minutes.");
         }
      }
   }
}
