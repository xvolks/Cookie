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
   public class AllianceInvitationStateRecruterMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6396;
       
      
      private var _isInitialized:Boolean = false;
      
      public var recrutedName:String = "";
      
      public var invitationState:uint = 0;
      
      public function AllianceInvitationStateRecruterMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6396;
      }
      
      public function initAllianceInvitationStateRecruterMessage(param1:String = "", param2:uint = 0) : AllianceInvitationStateRecruterMessage
      {
         this.recrutedName = param1;
         this.invitationState = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.recrutedName = "";
         this.invitationState = 0;
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
         this.serializeAs_AllianceInvitationStateRecruterMessage(param1);
      }
      
      public function serializeAs_AllianceInvitationStateRecruterMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.recrutedName);
         param1.writeByte(this.invitationState);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceInvitationStateRecruterMessage(param1);
      }
      
      public function deserializeAs_AllianceInvitationStateRecruterMessage(param1:ICustomDataInput) : void
      {
         this._recrutedNameFunc(param1);
         this._invitationStateFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceInvitationStateRecruterMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceInvitationStateRecruterMessage(param1:FuncTree) : void
      {
         param1.addChild(this._recrutedNameFunc);
         param1.addChild(this._invitationStateFunc);
      }
      
      private function _recrutedNameFunc(param1:ICustomDataInput) : void
      {
         this.recrutedName = param1.readUTF();
      }
      
      private function _invitationStateFunc(param1:ICustomDataInput) : void
      {
         this.invitationState = param1.readByte();
         if(this.invitationState < 0)
         {
            throw new Error("Forbidden value (" + this.invitationState + ") on element of AllianceInvitationStateRecruterMessage.invitationState.");
         }
      }
   }
}
