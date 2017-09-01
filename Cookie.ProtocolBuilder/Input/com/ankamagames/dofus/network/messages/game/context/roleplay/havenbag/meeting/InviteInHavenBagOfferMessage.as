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
   public class InviteInHavenBagOfferMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6643;
       
      
      private var _isInitialized:Boolean = false;
      
      public var hostInformations:CharacterMinimalInformations;
      
      public var timeLeftBeforeCancel:int = 0;
      
      private var _hostInformationstree:FuncTree;
      
      public function InviteInHavenBagOfferMessage()
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
         return 6643;
      }
      
      public function initInviteInHavenBagOfferMessage(param1:CharacterMinimalInformations = null, param2:int = 0) : InviteInHavenBagOfferMessage
      {
         this.hostInformations = param1;
         this.timeLeftBeforeCancel = param2;
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
         this.serializeAs_InviteInHavenBagOfferMessage(param1);
      }
      
      public function serializeAs_InviteInHavenBagOfferMessage(param1:ICustomDataOutput) : void
      {
         this.hostInformations.serializeAs_CharacterMinimalInformations(param1);
         param1.writeVarInt(this.timeLeftBeforeCancel);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_InviteInHavenBagOfferMessage(param1);
      }
      
      public function deserializeAs_InviteInHavenBagOfferMessage(param1:ICustomDataInput) : void
      {
         this.hostInformations = new CharacterMinimalInformations();
         this.hostInformations.deserialize(param1);
         this._timeLeftBeforeCancelFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_InviteInHavenBagOfferMessage(param1);
      }
      
      public function deserializeAsyncAs_InviteInHavenBagOfferMessage(param1:FuncTree) : void
      {
         this._hostInformationstree = param1.addChild(this._hostInformationstreeFunc);
         param1.addChild(this._timeLeftBeforeCancelFunc);
      }
      
      private function _hostInformationstreeFunc(param1:ICustomDataInput) : void
      {
         this.hostInformations = new CharacterMinimalInformations();
         this.hostInformations.deserializeAsync(this._hostInformationstree);
      }
      
      private function _timeLeftBeforeCancelFunc(param1:ICustomDataInput) : void
      {
         this.timeLeftBeforeCancel = param1.readVarInt();
      }
   }
}
