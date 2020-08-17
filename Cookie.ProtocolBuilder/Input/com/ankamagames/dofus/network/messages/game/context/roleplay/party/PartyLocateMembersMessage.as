package com.ankamagames.dofus.network.messages.game.context.roleplay.party
{
   import com.ankamagames.dofus.network.types.game.context.roleplay.party.PartyMemberGeoPosition;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class PartyLocateMembersMessage extends AbstractPartyMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5595;
       
      
      private var _isInitialized:Boolean = false;
      
      public var geopositions:Vector.<PartyMemberGeoPosition>;
      
      private var _geopositionstree:FuncTree;
      
      public function PartyLocateMembersMessage()
      {
         this.geopositions = new Vector.<PartyMemberGeoPosition>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5595;
      }
      
      public function initPartyLocateMembersMessage(param1:uint = 0, param2:Vector.<PartyMemberGeoPosition> = null) : PartyLocateMembersMessage
      {
         super.initAbstractPartyMessage(param1);
         this.geopositions = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.geopositions = new Vector.<PartyMemberGeoPosition>();
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
         this.serializeAs_PartyLocateMembersMessage(param1);
      }
      
      public function serializeAs_PartyLocateMembersMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractPartyMessage(param1);
         param1.writeShort(this.geopositions.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.geopositions.length)
         {
            (this.geopositions[_loc2_] as PartyMemberGeoPosition).serializeAs_PartyMemberGeoPosition(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyLocateMembersMessage(param1);
      }
      
      public function deserializeAs_PartyLocateMembersMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:PartyMemberGeoPosition = null;
         super.deserialize(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new PartyMemberGeoPosition();
            _loc4_.deserialize(param1);
            this.geopositions.push(_loc4_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyLocateMembersMessage(param1);
      }
      
      public function deserializeAsyncAs_PartyLocateMembersMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         this._geopositionstree = param1.addChild(this._geopositionstreeFunc);
      }
      
      private function _geopositionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._geopositionstree.addChild(this._geopositionsFunc);
            _loc3_++;
         }
      }
      
      private function _geopositionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:PartyMemberGeoPosition = new PartyMemberGeoPosition();
         _loc2_.deserialize(param1);
         this.geopositions.push(_loc2_);
      }
   }
}
