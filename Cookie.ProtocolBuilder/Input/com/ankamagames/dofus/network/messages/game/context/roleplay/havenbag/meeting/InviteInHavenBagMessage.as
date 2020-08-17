package com.ankamagames.dofus.network.messages.game.context.roleplay.havenbag.meeting
{
   import com.ankamagames.dofus.network.types.game.character.CharacterMinimalInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class InviteInHavenBagMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6642;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guestInformations:CharacterMinimalInformations;
      
      public var accept:Boolean = false;
      
      private var _guestInformationstree:FuncTree;
      
      public function InviteInHavenBagMessage()
      {
         this.guestInformations = new CharacterMinimalInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6642;
      }
      
      public function initInviteInHavenBagMessage(param1:CharacterMinimalInformations = null, param2:Boolean = false) : InviteInHavenBagMessage
      {
         this.guestInformations = param1;
         this.accept = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guestInformations = new CharacterMinimalInformations();
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
         this.serializeAs_InviteInHavenBagMessage(param1);
      }
      
      public function serializeAs_InviteInHavenBagMessage(param1:ICustomDataOutput) : void
      {
         this.guestInformations.serializeAs_CharacterMinimalInformations(param1);
         param1.writeBoolean(this.accept);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InviteInHavenBagMessage(param1);
      }
      
      public function deserializeAs_InviteInHavenBagMessage(param1:ICustomDataInput) : void
      {
         this.guestInformations = new CharacterMinimalInformations();
         this.guestInformations.deserialize(param1);
         this._acceptFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InviteInHavenBagMessage(param1);
      }
      
      public function deserializeAsyncAs_InviteInHavenBagMessage(param1:FuncTree) : void
      {
         this._guestInformationstree = param1.addChild(this._guestInformationstreeFunc);
         param1.addChild(this._acceptFunc);
      }
      
      private function _guestInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.guestInformations = new CharacterMinimalInformations();
         this.guestInformations.deserializeAsync(this._guestInformationstree);
      }
      
      private function _acceptFunc(param1:ICustomDataInput) : void
      {
         this.accept = param1.readBoolean();
      }
   }
}
