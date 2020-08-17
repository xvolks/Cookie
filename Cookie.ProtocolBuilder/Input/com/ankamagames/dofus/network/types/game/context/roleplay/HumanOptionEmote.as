package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class HumanOptionEmote extends HumanOption implements INetworkType
   {
      
      public static const protocolId:uint = 407;
       
      
      public var emoteId:uint = 0;
      
      public var emoteStartTime:Number = 0;
      
      public function HumanOptionEmote()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 407;
      }
      
      public function initHumanOptionEmote(param1:uint = 0, param2:Number = 0) : HumanOptionEmote
      {
         this.emoteId = param1;
         this.emoteStartTime = param2;
         return this;
      }
      
      override public function reset() : void
      {
         this.emoteId = 0;
         this.emoteStartTime = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanOptionEmote(param1);
      }
      
      public function serializeAs_HumanOptionEmote(param1:ICustomDataOutput) : void
      {
         super.serializeAs_HumanOption(param1);
         if(this.emoteId < 0 || this.emoteId > 255)
         {
            throw new Error("Forbidden value (" + this.emoteId + ") on element emoteId.");
         }
         param1.writeByte(this.emoteId);
         if(this.emoteStartTime < -9007199254740990 || this.emoteStartTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.emoteStartTime + ") on element emoteStartTime.");
         }
         param1.writeDouble(this.emoteStartTime);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanOptionEmote(param1);
      }
      
      public function deserializeAs_HumanOptionEmote(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._emoteIdFunc(param1);
         this._emoteStartTimeFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanOptionEmote(param1);
      }
      
      public function deserializeAsyncAs_HumanOptionEmote(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._emoteIdFunc);
         param1.addChild(this._emoteStartTimeFunc);
      }
      
      private function _emoteIdFunc(param1:ICustomDataInput) : void
      {
         this.emoteId = param1.readUnsignedByte();
         if(this.emoteId < 0 || this.emoteId > 255)
         {
            throw new Error("Forbidden value (" + this.emoteId + ") on element of HumanOptionEmote.emoteId.");
         }
      }
      
      private function _emoteStartTimeFunc(param1:ICustomDataInput) : void
      {
         this.emoteStartTime = param1.readDouble();
         if(this.emoteStartTime < -9007199254740990 || this.emoteStartTime > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.emoteStartTime + ") on element of HumanOptionEmote.emoteStartTime.");
         }
      }
   }
}
