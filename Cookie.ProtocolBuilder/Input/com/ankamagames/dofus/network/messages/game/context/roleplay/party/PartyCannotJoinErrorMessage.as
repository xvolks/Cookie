package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyCannotJoinErrorMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5583;
       
      
      private var _isInitialized:Boolean = false;
      
      public var reason:uint = 0;
      
      public function PartyCannotJoinErrorMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5583;
      }
      
      public function initPartyCannotJoinErrorMessage(param1:uint = 0, param2:uint = 0) : PartyCannotJoinErrorMessage
      {
         super.initAbstractPartyMessage(param1);
         this.reason = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.reason = 0;
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
         this.serializeAs_PartyCannotJoinErrorMessage(param1);
      }
      
      public function serializeAs_PartyCannotJoinErrorMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeByte(this.reason);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyCannotJoinErrorMessage(param1);
      }
      
      public function deserializeAs_PartyCannotJoinErrorMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._reasonFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyCannotJoinErrorMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyCannotJoinErrorMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._reasonFunc);
      }
      
      private function _reasonFunc(param1:ICustomDataInput) : void
      {
         this.reason = param1.readByte();
         if(this.reason < 0)
         {
            throw new Error("Forbidden value (" + this.reason + ") on element of PartyCannotJoinErrorMessage.reason.");
         }
      }
   }
}
