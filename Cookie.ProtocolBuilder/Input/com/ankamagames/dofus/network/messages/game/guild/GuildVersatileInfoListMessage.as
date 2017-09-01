package com.ankamagames.dofus.network.messages.game.guild
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.social.GuildVersatileInformations;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class GuildVersatileInfoListMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6435;
       
      
      private var _isInitialized:Boolean = false;
      
      public var guilds:Vector.<GuildVersatileInformations>;
      
      private var _guildstree:FuncTree;
      
      public function GuildVersatileInfoListMessage()
      {
         this.guilds = new Vector.<GuildVersatileInformations>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6435;
      }
      
      public function initGuildVersatileInfoListMessage(param1:Vector.<GuildVersatileInformations> = null) : GuildVersatileInfoListMessage
      {
         this.guilds = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.guilds = new Vector.<GuildVersatileInformations>();
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
         this.serializeAs_GuildVersatileInfoListMessage(param1);
      }
      
      public function serializeAs_GuildVersatileInfoListMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.guilds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.guilds.length)
         {
            param1.writeShort((this.guilds[_loc2_] as GuildVersatileInformations).getTypeId());
            (this.guilds[_loc2_] as GuildVersatileInformations).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GuildVersatileInfoListMessage(param1);
      }
      
      public function deserializeAs_GuildVersatileInfoListMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:GuildVersatileInformations = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(GuildVersatileInformations,_loc4_);
            _loc5_.deserialize(param1);
            this.guilds.push(_loc5_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GuildVersatileInfoListMessage(param1);
      }
      
      public function deserializeAsyncAs_GuildVersatileInfoListMessage(param1:FuncTree) : void
      {
         this._guildstree = param1.addChild(this._guildstreeFunc);
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
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:GuildVersatileInformations = ProtocolTypeManager.getInstance(GuildVersatileInformations,_loc2_);
         _loc3_.deserialize(param1);
         this.guilds.push(_loc3_);
      }
   }
}
