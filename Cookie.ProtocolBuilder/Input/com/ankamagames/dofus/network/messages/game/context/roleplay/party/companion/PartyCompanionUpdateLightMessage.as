package com.ankamagames.dofus.network.messages.game.context.roleplay.party.companion
{
   import com.ankamagames.dofus.network.messages.game.context.roleplay.party.PartyUpdateLightMessage;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyCompanionUpdateLightMessage extends PartyUpdateLightMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6472;
       
      
      private var _isInitialized:Boolean = false;
      
      public var indexId:uint = 0;
      
      public function PartyCompanionUpdateLightMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6472;
      }
      
      public function initPartyCompanionUpdateLightMessage(param1:uint = 0, param2:Number = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:uint = 0) : PartyCompanionUpdateLightMessage
      {
         super.initPartyUpdateLightMessage(param1,param2,param3,param4,param5,param6);
         this.indexId = param7;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.indexId = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyCompanionUpdateLightMessage(param1);
      }
      
      public function serializeAs_PartyCompanionUpdateLightMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PartyUpdateLightMessage(param1);
         if(this.indexId < 0)
         {
            throw new Error("Forbidden value (" + this.indexId + ") on element indexId.");
         }
         param1.writeByte(this.indexId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyCompanionUpdateLightMessage(param1);
      }
      
      public function deserializeAs_PartyCompanionUpdateLightMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._indexIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyCompanionUpdateLightMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyCompanionUpdateLightMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._indexIdFunc);
      }
      
      private function _indexIdFunc(param1:ICustomDataInput) : void
      {
         this.indexId = param1.readByte();
         if(this.indexId < 0)
         {
            throw new Error("Forbidden value (" + this.indexId + ") on element of PartyCompanionUpdateLightMessage.indexId.");
         }
      }
   }
}
