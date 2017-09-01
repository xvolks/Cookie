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
   public class InviteInHavenBagClosedMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6645;
       
      
      private var _isInitialized:Boolean = false;
      
      public var hostInformations:CharacterMinimalInformations;
      
      private var _hostInformationstree:FuncTree;
      
      public function InviteInHavenBagClosedMessage()
      {
         this.hostInformations = new CharacterMinimalInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6645;
      }
      
      public function initInviteInHavenBagClosedMessage(param1:CharacterMinimalInformations = null) : InviteInHavenBagClosedMessage
      {
         this.hostInformations = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.hostInformations = new CharacterMinimalInformations();
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
         this.serializeAs_InviteInHavenBagClosedMessage(param1);
      }
      
      public function serializeAs_InviteInHavenBagClosedMessage(param1:ICustomDataOutput) : void
      {
         this.hostInformations.serializeAs_CharacterMinimalInformations(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InviteInHavenBagClosedMessage(param1);
      }
      
      public function deserializeAs_InviteInHavenBagClosedMessage(param1:ICustomDataInput) : void
      {
         this.hostInformations = new CharacterMinimalInformations();
         this.hostInformations.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InviteInHavenBagClosedMessage(param1);
      }
      
      public function deserializeAsyncAs_InviteInHavenBagClosedMessage(param1:FuncTree) : void
      {
         this._hostInformationstree = param1.addChild(this._hostInformationstreeFunc);
      }
      
      private function _hostInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.hostInformations = new CharacterMinimalInformations();
         this.hostInformations.deserializeAsync(this._hostInformationstree);
      }
   }
}
