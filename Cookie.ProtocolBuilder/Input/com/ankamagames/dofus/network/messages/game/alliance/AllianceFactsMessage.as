package com.ankamagames.dofus.network.messages.game.alliance
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.roleplay.GuildInAllianceInformations;
   import com.ankamagames.dofus.network.types.game.social.AllianceFactSheetInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AllianceFactsMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6414;
       
      
      private var _isInitialized:Boolean = false;
      
      public var infos:AllianceFactSheetInformations;
      
      public var guilds:Vector.<GuildInAllianceInformations>;
      
      public var controlledSubareaIds:Vector.<uint>;
      
      public var leaderCharacterId:Number = 0;
      
      public var leaderCharacterName:String = "";
      
      private var _infostree:FuncTree;
      
      private var _guildstree:FuncTree;
      
      private var _controlledSubareaIdstree:FuncTree;
      
      public function AllianceFactsMessage()
      {
         this.infos = new AllianceFactSheetInformations();
         this.guilds = new Vector.<GuildInAllianceInformations>();
         this.controlledSubareaIds = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6414;
      }
      
      public function initAllianceFactsMessage(param1:AllianceFactSheetInformations = null, param2:Vector.<GuildInAllianceInformations> = null, param3:Vector.<uint> = null, param4:Number = 0, param5:String = "") : AllianceFactsMessage
      {
         this.infos = param1;
         this.guilds = param2;
         this.controlledSubareaIds = param3;
         this.leaderCharacterId = param4;
         this.leaderCharacterName = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.infos = new AllianceFactSheetInformations();
         this.controlledSubareaIds = new Vector.<uint>();
         this.leaderCharacterId = 0;
         this.leaderCharacterName = "";
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
         this.serializeAs_AllianceFactsMessage(param1);
      }
      
      public function serializeAs_AllianceFactsMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.infos.getTypeId());
         this.infos.serialize(param1);
         param1.writeShort(this.guilds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.guilds.length)
         {
            (this.guilds[_loc2_] as GuildInAllianceInformations).serializeAs_GuildInAllianceInformations(param1);
            _loc2_++;
         }
         param1.writeShort(this.controlledSubareaIds.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.controlledSubareaIds.length)
         {
            if(this.controlledSubareaIds[_loc3_] < 0)
            {
               throw new Error("Forbidden value (" + this.controlledSubareaIds[_loc3_] + ") on element 3 (starting at 1) of controlledSubareaIds.");
            }
            param1.writeVarShort(this.controlledSubareaIds[_loc3_]);
            _loc3_++;
         }
         if(this.leaderCharacterId < 0 || this.leaderCharacterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderCharacterId + ") on element leaderCharacterId.");
         }
         param1.writeVarLong(this.leaderCharacterId);
         param1.writeUTF(this.leaderCharacterName);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AllianceFactsMessage(param1);
      }
      
      public function deserializeAs_AllianceFactsMessage(param1:ICustomDataInput) : void
      {
         var _loc7_:GuildInAllianceInformations = null;
         var _loc8_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         this.infos = ProtocolTypeManager.getInstance(AllianceFactSheetInformations,_loc2_);
         this.infos.deserialize(param1);
         var _loc3_:uint = param1.readUnsignedShort();
         var _loc4_:uint = 0;
         while(_loc4_ < _loc3_)
         {
            _loc7_ = new GuildInAllianceInformations();
            _loc7_.deserialize(param1);
            this.guilds.push(_loc7_);
            _loc4_++;
         }
         var _loc5_:uint = param1.readUnsignedShort();
         var _loc6_:uint = 0;
         while(_loc6_ < _loc5_)
         {
            _loc8_ = param1.readVarUhShort();
            if(_loc8_ < 0)
            {
               throw new Error("Forbidden value (" + _loc8_ + ") on elements of controlledSubareaIds.");
            }
            this.controlledSubareaIds.push(_loc8_);
            _loc6_++;
         }
         this._leaderCharacterIdFunc(param1);
         this._leaderCharacterNameFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AllianceFactsMessage(param1);
      }
      
      public function deserializeAsyncAs_AllianceFactsMessage(param1:FuncTree) : void
      {
         this._infostree = param1.addChild(this._infostreeFunc);
         this._guildstree = param1.addChild(this._guildstreeFunc);
         this._controlledSubareaIdstree = param1.addChild(this._controlledSubareaIdstreeFunc);
         param1.addChild(this._leaderCharacterIdFunc);
         param1.addChild(this._leaderCharacterNameFunc);
      }
      
      private function _infostreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.infos = ProtocolTypeManager.getInstance(AllianceFactSheetInformations,_loc2_);
         this.infos.deserializeAsync(this._infostree);
      }
      
      private function _guildstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._guildstree.addChild(this._guildsFunc);
            _loc3_++;
         }
      }
      
      private function _guildsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:GuildInAllianceInformations = new GuildInAllianceInformations();
         _loc2_.deserialize(param1);
         this.guilds.push(_loc2_);
      }
      
      private function _controlledSubareaIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._controlledSubareaIdstree.addChild(this._controlledSubareaIdsFunc);
            _loc3_++;
         }
      }
      
      private function _controlledSubareaIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readVarUhShort();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of controlledSubareaIds.");
         }
         this.controlledSubareaIds.push(_loc2_);
      }
      
      private function _leaderCharacterIdFunc(param1:ICustomDataInput) : void
      {
         this.leaderCharacterId = param1.readVarUhLong();
         if(this.leaderCharacterId < 0 || this.leaderCharacterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.leaderCharacterId + ") on element of AllianceFactsMessage.leaderCharacterId.");
         }
      }
      
      private function _leaderCharacterNameFunc(param1:ICustomDataInput) : void
      {
         this.leaderCharacterName = param1.readUTF();
      }
   }
}
