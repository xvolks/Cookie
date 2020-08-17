package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.dofus.network.types.game.social.AllianceVersatileInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceVersatileInfoListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6436;
       
      
      private var _isInitialized:Boolean = false;
      
      public var alliances:Vector.<AllianceVersatileInformations>;
      
      private var _alliancestree:FuncTree;
      
      public function AllianceVersatileInfoListMessage()
      {
         this.alliances = new Vector.<AllianceVersatileInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6436;
      }
      
      public function initAllianceVersatileInfoListMessage(param1:Vector.<AllianceVersatileInformations> = null) : AllianceVersatileInfoListMessage
      {
         this.alliances = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.alliances = new Vector.<AllianceVersatileInformations>();
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
         this.serializeAs_AllianceVersatileInfoListMessage(param1);
      }
      
      public function serializeAs_AllianceVersatileInfoListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.alliances.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.alliances.length)
         {
            (this.alliances[_loc2_] as AllianceVersatileInformations).serializeAs_AllianceVersatileInformations(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceVersatileInfoListMessage(param1);
      }
      
      public function deserializeAs_AllianceVersatileInfoListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:AllianceVersatileInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new AllianceVersatileInformations();
            _loc4_.deserialize(param1);
            this.alliances.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceVersatileInfoListMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceVersatileInfoListMessage(param1:FuncTree) : void
      {
         this._alliancestree = param1.addChild(this._alliancestreeFunc);
      }
      
      private function _alliancestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._alliancestree.addChild(this._alliancesFunc);
            _loc3_++;
         }
      }
      
      private function _alliancesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:AllianceVersatileInformations = new AllianceVersatileInformations();
         _loc2_.deserialize(param1);
         this.alliances.push(_loc2_);
      }
   }
}
