package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyMemberEjectedMessage extends PartyMemberRemoveMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6252;
       
      
      private var _isInitialized:Boolean = false;
      
      public var kickerId:Number = 0;
      
      public function PartyMemberEjectedMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6252;
      }
      
      public function initPartyMemberEjectedMessage(param1:uint = 0, param2:Number = 0, param3:Number = 0) : PartyMemberEjectedMessage
      {
         super.initPartyMemberRemoveMessage(param1,param2);
         this.kickerId = param3;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.kickerId = 0;
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
         this.serializeAs_PartyMemberEjectedMessage(param1);
      }
      
      public function serializeAs_PartyMemberEjectedMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PartyMemberRemoveMessage(param1);
         if(this.kickerId < 0 || this.kickerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kickerId + ") on element kickerId.");
         }
         param1.writeVarLong(this.kickerId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyMemberEjectedMessage(param1);
      }
      
      public function deserializeAs_PartyMemberEjectedMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._kickerIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyMemberEjectedMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyMemberEjectedMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._kickerIdFunc);
      }
      
      private function _kickerIdFunc(param1:ICustomDataInput) : void
      {
         this.kickerId = param1.readVarUhLong();
         if(this.kickerId < 0 || this.kickerId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.kickerId + ") on element of PartyMemberEjectedMessage.kickerId.");
         }
      }
   }
}
