package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceInvitationMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6395;
       
      
      private var _isInitialized:Boolean = false;
      
      public var targetId:Number = 0;
      
      public function AllianceInvitationMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6395;
      }
      
      public function initAllianceInvitationMessage(param1:Number = 0) : AllianceInvitationMessage
      {
         this.targetId = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.targetId = 0;
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
         this.serializeAs_AllianceInvitationMessage(param1);
      }
      
      public function serializeAs_AllianceInvitationMessage(param1:ICustomDataOutput) : void
      {
         if(this.targetId < 0 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element targetId.");
         }
         param1.writeVarLong(this.targetId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceInvitationMessage(param1);
      }
      
      public function deserializeAs_AllianceInvitationMessage(param1:ICustomDataInput) : void
      {
         this._targetIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceInvitationMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceInvitationMessage(param1:FuncTree) : void
      {
         param1.addChild(this._targetIdFunc);
      }
      
      private function _targetIdFunc(param1:ICustomDataInput) : void
      {
         this.targetId = param1.readVarUhLong();
         if(this.targetId < 0 || this.targetId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.targetId + ") on element of AllianceInvitationMessage.targetId.");
         }
      }
   }
}
