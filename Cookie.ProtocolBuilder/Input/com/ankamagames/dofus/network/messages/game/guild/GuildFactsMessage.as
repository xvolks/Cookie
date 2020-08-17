package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.character.CharacterMinimalInformations;
   import com.ankamagames.dofus.network.types.game.social.GuildFactSheetInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildFactsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6415;
       
      
      private var _isInitialized:Boolean = false;
      
      public var infos:GuildFactSheetInformations;
      
      public var creationDate:uint = 0;
      
      public var nbTaxCollectors:uint = 0;
      
      public var members:Vector.<CharacterMinimalInformations>;
      
      private var _infostree:FuncTree;
      
      private var _memberstree:FuncTree;
      
      public function GuildFactsMessage()
      {
         this.infos = new GuildFactSheetInformations();
         this.members = new Vector.<CharacterMinimalInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6415;
      }
      
      public function initGuildFactsMessage(param1:GuildFactSheetInformations = null, param2:uint = 0, param3:uint = 0, param4:Vector.<CharacterMinimalInformations> = null) : GuildFactsMessage
      {
         this.infos = param1;
         this.creationDate = param2;
         this.nbTaxCollectors = param3;
         this.members = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.infos = new GuildFactSheetInformations();
         this.nbTaxCollectors = 0;
         this.members = new Vector.<CharacterMinimalInformations>();
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
         this.serializeAs_GuildFactsMessage(param1);
      }
      
      public function serializeAs_GuildFactsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.infos.getTypeId());
         this.infos.serialize(param1);
         if(this.creationDate < 0)
         {
            throw new Error("Forbidden value (" + this.creationDate + ") on element creationDate.");
         }
         param1.writeInt(this.creationDate);
         if(this.nbTaxCollectors < 0)
         {
            throw new Error("Forbidden value (" + this.nbTaxCollectors + ") on element nbTaxCollectors.");
         }
         param1.writeVarShort(this.nbTaxCollectors);
         param1.writeShort(this.members.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.members.length)
         {
            (this.members[_loc2_] as CharacterMinimalInformations).serializeAs_CharacterMinimalInformations(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildFactsMessage(param1);
      }
      
      public function deserializeAs_GuildFactsMessage(param1:ICustomDataInput) : void
      {
         var _loc5_:CharacterMinimalInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         this.infos = ProtocolTypeManager.getInstance(GuildFactSheetInformations,_loc2_);
         this.infos.deserialize(param1);
         this._creationDateFunc(param1);
         this._nbTaxCollectorsFunc(param1);
         var _loc3_:uint = param1.readUnsignedShort();
         var _loc4_:uint = 0;
         while(_loc4_ < _loc3_)
         {
            _loc5_ = new CharacterMinimalInformations();
            _loc5_.deserialize(param1);
            this.members.push(_loc5_);
            _loc4_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildFactsMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildFactsMessage(param1:FuncTree) : void
      {
         this._infostree = param1.addChild(this._infostreeFunc);
         param1.addChild(this._creationDateFunc);
         param1.addChild(this._nbTaxCollectorsFunc);
         this._memberstree = param1.addChild(this._memberstreeFunc);
      }
      
      private function _infostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.infos = ProtocolTypeManager.getInstance(GuildFactSheetInformations,_loc2_);
         this.infos.deserializeAsync(this._infostree);
      }
      
      private function _creationDateFunc(param1:ICustomDataInput) : void
      {
         this.creationDate = param1.readInt();
         if(this.creationDate < 0)
         {
            throw new Error("Forbidden value (" + this.creationDate + ") on element of GuildFactsMessage.creationDate.");
         }
      }
      
      private function _nbTaxCollectorsFunc(param1:ICustomDataInput) : void
      {
         this.nbTaxCollectors = param1.readVarUhShort();
         if(this.nbTaxCollectors < 0)
         {
            throw new Error("Forbidden value (" + this.nbTaxCollectors + ") on element of GuildFactsMessage.nbTaxCollectors.");
         }
      }
      
      private function _memberstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._memberstree.addChild(this._membersFunc);
            _loc3_++;
         }
      }
      
      private function _membersFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:CharacterMinimalInformations = new CharacterMinimalInformations();
         _loc2_.deserialize(param1);
         this.members.push(_loc2_);
      }
   }
}
