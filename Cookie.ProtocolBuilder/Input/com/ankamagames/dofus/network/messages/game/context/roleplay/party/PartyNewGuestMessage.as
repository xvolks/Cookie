package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyGuestInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   public class PartyNewGuestMessage extends AbstractPartyEventMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6260;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guest:PartyGuestInformations;
      
      private var _guesttree:FuncTree;
      
      public function PartyNewGuestMessage()
      {
         this.guest = new PartyGuestInformations();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6260;
      }
      
      public function initPartyNewGuestMessage(param1:uint = 0, param2:PartyGuestInformations = null) : PartyNewGuestMessage
      {
         super.initAbstractPartyEventMessage(param1);
         this.guest = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.guest = new PartyGuestInformations();
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
         this.serializeAs_PartyNewGuestMessage(param1);
      }
      
      public function serializeAs_PartyNewGuestMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyEventMessage(param1);
         this.guest.serializeAs_PartyGuestInformations(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyNewGuestMessage(param1);
      }
      
      public function deserializeAs_PartyNewGuestMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this.guest = new PartyGuestInformations();
         this.guest.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyNewGuestMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyNewGuestMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._guesttree = param1.addChild(this._guesttreeFunc);
      }
      
      private function _guesttreeFunc(param1:ICustomDataInput) : void
      {
         this.guest = new PartyGuestInformations();
         this.guest.deserializeAsync(this._guesttree);
      }
   }
}
