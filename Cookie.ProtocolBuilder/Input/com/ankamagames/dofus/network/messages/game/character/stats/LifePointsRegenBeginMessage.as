package com.ankamagames.dofus.network.messages.game.character.stats
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class LifePointsRegenBeginMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5684;
       
      
      private var _isInitialized:Boolean = false;
      
      public var regenRate:uint = 0;
      
      public function LifePointsRegenBeginMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5684;
      }
      
      public function initLifePointsRegenBeginMessage(param1:uint = 0) : LifePointsRegenBeginMessage
      {
         this.regenRate = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.regenRate = 0;
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_LifePointsRegenBeginMessage(param1);
      }
      
      public function serializeAs_LifePointsRegenBeginMessage(param1:ICustomDataOutput) : void
      {
         if(this.regenRate < 0 || this.regenRate > 255)
         {
            throw new Error("Forbidden value (" + this.regenRate + ") on element regenRate.");
         }
         param1.writeByte(this.regenRate);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_LifePointsRegenBeginMessage(param1);
      }
      
      public function deserializeAs_LifePointsRegenBeginMessage(param1:ICustomDataInput) : void
      {
         this._regenRateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_LifePointsRegenBeginMessage(param1);
      }
      
      public function deserializeAsyncAs_LifePointsRegenBeginMessage(param1:FuncTree) : void
      {
         param1.addChild(this._regenRateFunc);
      }
      
      private function _regenRateFunc(param1:ICustomDataInput) : void
      {
         this.regenRate = param1.readUnsignedByte();
         if(this.regenRate < 0 || this.regenRate > 255)
         {
            throw new Error("Forbidden value (" + this.regenRate + ") on element of LifePointsRegenBeginMessage.regenRate.");
         }
      }
   }
}
